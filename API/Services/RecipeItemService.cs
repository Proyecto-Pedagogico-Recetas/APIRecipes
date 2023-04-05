using API.IServices;
using Entities.Entities;
using Logic.Ilogic;

namespace API.Services
{
    public class RecipeItemService : IRecipeItemService
    {
        private readonly IRecipeItemLogic _recipeItemLogic;

        public RecipeItemService(IRecipeItemLogic recipeItemLogic)
        {
            _recipeItemLogic = recipeItemLogic;
        }

        public int InsertRecipe(RecipeItem recipeItem)
        {
            _recipeItemLogic.InsertRecipe(recipeItem);
            return recipeItem.Id;
        }
    }
}
