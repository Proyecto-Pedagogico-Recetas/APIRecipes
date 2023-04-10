using Entities.Entities;

namespace API.IServices
{
    public interface IRecipeItemService
    {
        int InsertRecipe(RecipeItem recipeItem);
        void DeleteRecipe(int id);
    }
}
