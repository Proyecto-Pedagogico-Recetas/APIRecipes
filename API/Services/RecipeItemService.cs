using API.IServices;
using Entities.Entities;
using Logic.Ilogic;
using Resources.RequestModels;

namespace API.Services
{
    public class RecipeItemService : IRecipeItemService
    {
        private readonly IRecipeItemLogic _recipeItemLogic;

        public RecipeItemService(IRecipeItemLogic recipeItemLogic)
        {
            _recipeItemLogic = recipeItemLogic;
        }

        public int InsertRecipe(RecipeRequest recipeRequest)
        {
            return _recipeItemLogic.InsertRecipe(recipeRequest);
            
        }

        public void DeleteRecipe(int id)
        {
            _recipeItemLogic.DeleteRecipe(id);
        }

        public async Task<RecipeItem> GetRecipes(int recipeId)
        {
            return await _recipeItemLogic.GetRecipes(recipeId);
        }
    }
}
