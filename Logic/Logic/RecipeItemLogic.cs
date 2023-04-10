using Data;
using Entities.Entities;
using Entities.Relations;
using Logic.Ilogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;

namespace Logic.Logic
{
    public class RecipeItemLogic : BaseContextLogic, IRecipeItemLogic
    {
        public RecipeItemLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public int InsertRecipe(RecipeItem recipeItem)
        { 

                // Agrega los ingredientes a la tabla intermedia
                foreach (var ingredient in recipeItem.Ingredients)
                {
                    var recipeIngredient = new IngredientItem
                    {
                       Id= ingredient.Id,
                       Name= ingredient.Name,
                        //IngredientId = ingredient
                    };
                    _serviceContext.Ingredients.Add(recipeIngredient);
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







            _serviceContext.Recipes.Add(recipeItem);
            _serviceContext.SaveChanges();
            return recipeItem.Id;
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

