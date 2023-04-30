using Data;
using Entities.Entities;
using Entities.Relations;
using Logic.Ilogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Resources.RequestModels;
 using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Logic.Logic
{
    public class RecipeItemLogic : BaseContextLogic, IRecipeItemLogic
    {
        public RecipeItemLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public async Task InsertRecipe(RecipeRequest recipeRequest)
        {

            var postedBy = await _serviceContext.Set<UserItem>()
                .Where(u => u.UserName == recipeRequest.PosterName)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
            var category = await _serviceContext.Set<CategoryItem>()
                .Where(c => c.Name == recipeRequest.Category)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
            var recipeData = new RecipeItem
            {
                Name = recipeRequest.Name,
                Instructions = recipeRequest.Instructions,
                Author = recipeRequest.Author,
                Materials = recipeRequest.Materials,
                Observations = recipeRequest.Observations,
                PostedBy = postedBy,
                PosterName = recipeRequest.PosterName,
                Category = recipeRequest.Category,
                CategoryId = category,
            };
            await _serviceContext.Recipes.AddAsync(recipeData);
            await _serviceContext.SaveChangesAsync();

            // Agrega los ingredientes a la tabla intermedia
            foreach (var ingredient in recipeRequest.Ingredients)
            {
                var existingIngredient = await _serviceContext.Ingredients
                    .FirstOrDefaultAsync(i => i.Ingredient == ingredient.Ingredient);
                if (existingIngredient == null)
                {
                    var ingredientToAdd = new IngredientItem
                    {
                        Ingredient = ingredient.Ingredient


                    };

                    await _serviceContext.Ingredients.AddAsync(ingredientToAdd);
                    await _serviceContext.SaveChangesAsync();
                    existingIngredient = ingredientToAdd;
                }

                var recipeIngredient = new Recipe_Ingredient
                {
                    IngredientName = existingIngredient.Ingredient,
                    RecipeName = recipeData.Name,
                    IngredientId = existingIngredient.Id,
                    RecipeId = recipeData.Id,
                    Amount = ingredient.Amount,
                    Unit = ingredient.Unit
                };
                await _serviceContext.Recipe_Ingredients.AddAsync(recipeIngredient);
                await _serviceContext.SaveChangesAsync();
            }

            foreach (var alergen in recipeRequest.Alergens)
            {
                var alergenRecipe = new Recipe_Alergen
                {
                    AlergenId = alergen.Id,
                    AlergenName = alergen.Name,
                    RecipeId = recipeData.Id,
                    RecipeName = recipeData.Name
                };
                await _serviceContext.Recipe_Alergens.AddAsync(alergenRecipe);
                await _serviceContext.SaveChangesAsync();
            }
            return;
        }





        void IRecipeItemLogic.DeleteRecipe(int id)
        {
            var recipeToDelete = _serviceContext.Set<RecipeItem>()
                  .Where(r => r.Id == id).First();

            recipeToDelete.IsActive = false;

            _serviceContext.SaveChanges();
        }

        public async Task<RecipeItem> GetRecipe(int recipeId)
        {

            //var recipes = _serviceContext.Recipes.Include(p => p.Alergens).ToList();
            //return recipes;

            //var recipeItem = _serviceContext.Set<RecipeItem>()
            //    .Include(r => r.Alergens)
            //    .Where(r => r.Id == id).FirstOrDefault();
            //var alergenList = recipeItem.Alergens;


            return await _serviceContext.Recipes
                    .Include(er => er.Alergens)
                    .ThenInclude(era => era.Alergens)
                    .Include(er => er.Ingredients)
                    .ThenInclude(eri => eri.Ingredients)
                    .FirstOrDefaultAsync(er => er.Id == recipeId);
        }

        public async Task<List<RecipeItem>> GetAllRecipes()
        {
            return await _serviceContext.Set<RecipeItem>()
                    .Where(p => p.IsActive == true)
                    .Include(er => er.Alergens)
                    .ThenInclude(era => era.Alergens)
                    .Include(er => er.Ingredients)
                    .ThenInclude(eri => eri.Ingredients)
                    .ToListAsync();
        }

        public void UpdateRecipe(int id, RecipePatchRequest recipePatchRequest)
        {
            var recipeItem = _serviceContext.Recipes.Find(id);
            if (recipeItem == null)
            {
                throw new ArgumentException($"Recipe with id {id} not found.");
            }

            // Actualizar valores de recipeItem con los de recipePatchRequest
            recipeItem.Name = recipePatchRequest.Name;
            recipeItem.Instructions = recipePatchRequest.Instructions;
            recipeItem.Author = recipePatchRequest.Author;
            recipeItem.Materials = recipePatchRequest.Materials;
            recipeItem.Observations = recipePatchRequest.Observations;
            //recipeItem.PosterName = recipePatchRequest.PosterName;
            recipeItem.Category = recipePatchRequest.Category;
            recipeItem.CategoryId = recipePatchRequest.CategoryId;

            // Eliminar ingredientes y alergenos existentes de recipeItem
            _serviceContext.Recipe_Ingredients.RemoveRange(_serviceContext.Recipe_Ingredients.Where(ri => ri.RecipeId == id));
            _serviceContext.Recipe_Alergens.RemoveRange(_serviceContext.Recipe_Alergens.Where(ra => ra.RecipeId == id));
            _serviceContext.SaveChanges();

            // Agregar nuevos ingredientes y alergenos a recipeItem
            foreach (var ingredient in recipePatchRequest.Ingredients)
            {
                var existingIngredient = _serviceContext.Ingredients.FirstOrDefault(i => i.Ingredient == ingredient.Ingredient);
                if (existingIngredient == null)
                {
                    existingIngredient = new IngredientItem
                    {
                        Ingredient = ingredient.Ingredient
                    };
                    _serviceContext.Ingredients.Add(existingIngredient);
                }

                var recipeIngredient = new Recipe_Ingredient
                {
                    IngredientName = ingredient.Ingredient,
                    RecipeName = recipePatchRequest.Name,
                    IngredientId = existingIngredient.Id,
                    RecipeId = id,
                    Amount = ingredient.Amount,
                    Unit = ingredient.Unit
                };
                _serviceContext.Recipe_Ingredients.Add(recipeIngredient);
            }
                foreach (var alergen in recipePatchRequest.Alergens)
                {
                    var alergenRecipe = new Recipe_Alergen
                    {
                        AlergenId = alergen.Id,
                        AlergenName = alergen.Name,
                        RecipeId = id,
                        RecipeName = recipePatchRequest.Name
                    };
                    _serviceContext.Recipe_Alergens.Add(alergenRecipe);
                }
            

            // Actualizar recipeItem en la base de datos
            _serviceContext.Recipes.Update(recipeItem);
            _serviceContext.SaveChanges();
        }

        //public void UpdateRecipe(int id, RecipePatchRequest recipePatchRequest)
        //{     
        //   _serviceContext.Recipe_Ingredients.RemoveRange(_serviceContext.Recipe_Ingredients.Where(ri => ri.RecipeId == id));
        //            _serviceContext.SaveChanges();
        //    _serviceContext.Recipe_Alergens.RemoveRange(_serviceContext.Recipe_Alergens.Where(ra => ra.RecipeId == id));
        //    _serviceContext.SaveChanges();

        //    _serviceContext.Recipes.Update()
        //    _serviceContext.SaveChanges();
        //    //var postedBy = await _serviceContext.Set<UserItem>()
        //    //   .Where(u => u.UserName == recipePatchRequest.PosterName)
        //    //   .Select(u => u.Id)
        //    //   .FirstOrDefaultAsync();
        //    //var category = await _serviceContext.Set<CategoryItem>()
        //    //    .Where(c => c.Name == recipePatchRequest.Category)
        //    //    .Select(c => c.Id)
        //    //    .FirstOrDefaultAsync()

        //    //var recipeToPatch = await _serviceContext.Set<RecipeItem>()

        //    //    .Where(r => r.Id == id)
        //    //    .FirstOrDefaultAsync();
        //    //{


        //    //    Id = recipePatchRequest.Id,
        //    //    Name = recipePatchRequest.Name,
        //    //    Instructions = recipePatchRequest.Instructions,
        //    //    Author = recipePatchRequest.Author,
        //    //    Materials = recipePatchRequest.Materials,
        //    //    Observations = recipePatchRequest.Observations,

        //    //    PosterName = recipePatchRequest.PosterName,
        //    //    Category = recipePatchRequest.Category,
        //    //    CategoryId = recipePatchRequest.CategoryId
        //    //};

        //    foreach (var ingredient in recipeItem.Ingredients)
        //    {
        //        var existingIngredient = _serviceContext.Ingredients
        //            .FirstOrDefault(i => i.Ingredient == ingredient.IngredientName);
        //        if (existingIngredient == null)
        //        {
        //            var ingredientToAdd = new IngredientItem
        //            {
        //                Ingredient = ingredient.IngredientName


        //            };

        //            _serviceContext.Ingredients.Add(ingredientToAdd);
        //            _serviceContext.SaveChanges();
        //            existingIngredient = ingredientToAdd;
        //        }


        //        var recipeIngredient = new Recipe_Ingredient
        //        {
        //            IngredientName = ingredient.IngredientName,
        //            RecipeName = recipeItem.Name,
        //            IngredientId = existingIngredient.Id,
        //            RecipeId = recipeItem.Id,
        //            Amount = ingredient.Amount,
        //            Unit = ingredient.Unit
        //        };

        //        _serviceContext.Recipe_Ingredients.AddAsync(recipeIngredient);
        //        _serviceContext.SaveChanges();

        //    }    
        //        foreach (var alergen in recipeItem.Alergens)
        //        //.FirstOrDefault(i => i.Ingredient == ingredient.IngredientName);
        //        {
        //        var alergenToAdd = _serviceContext.Alergens.FirstOrDefault(a => a.Name == alergen.AlergenName);
        //            var alergenRecipe = new Recipe_Alergen
        //            {
        //                AlergenId = alergenToAdd.Id,
        //                AlergenName = alergen.AlergenName,
        //                RecipeId = recipeItem.Id,
        //                RecipeName = recipeItem.Name
        //            };

        //            _serviceContext.Recipe_Alergens.Add(alergenRecipe);
        //             _serviceContext.SaveChanges();
        //        }


        //    }

    }
}



//var recipeData =  _serviceContext.Set<RecipeItem>().ToList();
//var alergens = _serviceContext.Set<Recipe_Alergen>().Where

//foreach (var recipe in recipeData) 
//{
//  recipeRequest.Name= recipe.Name;
//  recipeRequest.Alergens = 
//}





//{
//    List<RecipeItem> recipes;
//    using (var context = new ServiceContext(Recipe))
//    {
//        recipes = _serviceContext.Recipes
//            .Include(r => r.Category)

//            .ToList();
//    }
//    return recipes;
//}