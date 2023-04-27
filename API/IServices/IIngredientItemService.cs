using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IIngredientItemService
    {

        List<IngredientItem> GetIngredients();

        int InsertIngredient(IngredientItem ingredientItem);

    }
}