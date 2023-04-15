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

        public int InsertRecipe(RecipeRequest recipeRequest)
        {
            var recipeData = new RecipeItem
            {

                Name = recipeRequest.Name,
                Instructions = recipeRequest.Instructions,
                Category = recipeRequest.Category,
                Author = recipeRequest.Author,
                Materials= recipeRequest.Materials,
                Observations=recipeRequest.Observations,

            };
            _serviceContext.Recipes.Add(recipeData);
            _serviceContext.SaveChanges();


            // Agrega los ingredientes a la tabla intermedia
            foreach (var ingredient in recipeRequest.Ingredients)
            {
                var ingredientToAdd = new IngredientItem
                {
    
                    Ingredient = ingredient.Ingredient
                };
                _serviceContext.Ingredients.Add(ingredientToAdd);
                _serviceContext.SaveChanges();




                var recipeIngredient = new Recipe_Ingredient
                {

                    IngredientName= ingredientToAdd.Ingredient,
                    RecipeName = recipeData.Name,
                    IngredientId = ingredientToAdd.Id,
                    RecipeId = recipeData.Id,
                    Amount = ingredient.Amount,
                    Unit = ingredient.Unit
    
                };
                _serviceContext.Recipe_Ingredients.Add(recipeIngredient);
                _serviceContext.SaveChanges();

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
                _serviceContext.Recipe_Alergens.Add(alergenRecipe);
                _serviceContext.SaveChanges();
            }




            _serviceContext.SaveChanges();
            return recipeData.Id;
        }




        void IRecipeItemLogic.DeleteRecipe(int id)
        {
            var recipeToDelete = _serviceContext.Set<RecipeItem>()
                  .Where(r => r.Id == id).First();

            recipeToDelete.IsActive = false;

            _serviceContext.SaveChanges();
        }

        public async Task<RecipeItem> GetRecipes(int recipeId)
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