using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IRecipeItemService
    {
        public Task InsertRecipe(RecipeRequest recipeRequest);
        void DeleteRecipe(int id);

        public Task<RecipeItem> GetRecipe(int recipeId);

        public Task<List<RecipeItem>> GetAllRecipes();

        public Task<List<RecipeItem>> GetRecipesByUser(int id);

        public void UpdateRecipe(int id, RecipePatchRequest recipePatchRequest);
    }
}
