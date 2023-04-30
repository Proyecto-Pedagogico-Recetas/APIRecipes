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

        public async Task InsertRecipe(RecipeRequest recipeRequest)
        {
            await _recipeItemLogic.InsertRecipe(recipeRequest);
            
        }

        public void DeleteRecipe(int id)
        {
            _recipeItemLogic.DeleteRecipe(id);
        }

        public async Task<RecipeItem> GetRecipe(int recipeId)
        {
            return await _recipeItemLogic.GetRecipe(recipeId);
        }

        public async Task<List<RecipeItem>> GetAllRecipes()
        {
            return await _recipeItemLogic.GetAllRecipes();
        }
        public void UpdateRecipe(int id, RecipePatchRequest recipePatchRequest)
        {
             _recipeItemLogic.UpdateRecipe(id, recipePatchRequest);
        }
    }
}
