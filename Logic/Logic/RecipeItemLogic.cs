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
                       .Include(er => er.Alergens)
                    .ThenInclude(era => era.Alergens)
                    .Include(er => er.Ingredients)
                    .ThenInclude(eri => eri.Ingredients)
                    .ToListAsync();
                    


        }
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