using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IRecipeItemService
    {
        int InsertRecipe(RecipeRequest recipeRequest);
        void DeleteRecipe(int id);

        public Task<RecipeItem> GetRecipe(int recipeId);

        public List<RecipeItem> GetAllRecipes();
    }
}
