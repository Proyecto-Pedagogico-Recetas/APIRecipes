using Data;
using Entities.Entities;
using Entities.Relations;
using Logic.Ilogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Resources.RequestModels;

namespace Logic.Logic
{
    public class RecipeItemLogic : BaseContextLogic, IRecipeItemLogic
    {
        public RecipeItemLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public int InsertRecipe (RecipeRequest recipeRequest)
        {
            var recipeData = new RecipeItem
            {
              
                Name = recipeRequest.Name,
                Instructions = recipeRequest.Instructions,
                Category = recipeRequest.Category,
                Author = recipeRequest.Author,

            };
            _serviceContext.Recipes.Add(recipeData);
            _serviceContext.SaveChanges();


            // Agrega los ingredientes a la tabla intermedia
            foreach (var ingredient in recipeRequest.Ingredients)
            {
                var ingredientToAdd = new IngredientItem
                {
                    //Id = ingredient.Id,
                    Ingredient = ingredient.Ingredient
                };
                _serviceContext.Ingredients.Add(ingredientToAdd);
                _serviceContext.SaveChanges();

                var recipeIngredient = new Recipe_Ingredient
                {
                   
                    //Name = ingredient.Name,
                    //RecipeId = recipeItem.Id,
                    IngredientId = ingredientToAdd.Id,
                    RecipeId = recipeData.Id,
                    Amount = ingredient.Amount,
                    Unit = ingredient.Unit
                    //IngredientId = ingredient
                };
                _serviceContext.Recipe_Ingredients.Add(recipeIngredient);
                _serviceContext.SaveChanges();

            }


                //foreach (var amount in recipeItem.Ingredients)
                //{
                //    var recipeIngredient = new Recipe_Ingredient
                //    {
                //        RecipeId = recipeItem.Id,
                //        //IngredientId = ingredient
                //    };
                //    _serviceContext.Recipe_Ingredients.Add(recipeIngredient);
                //}



                //await _context.SaveChangesAsync();

                //return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);

            
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
    }
}

