using API.IServices;
using Entities.Entities;
using Logic.Ilogic;
using Logic.Logic;
using Resources.RequestModels;

namespace API.Services
{
    public class IngredientItemService : IIngredientItemService

    { private readonly IngredientItemLogic _ingredientItemLogic;

        public  IngredientItemService(IngredientItemLogic ingredientItemLogic)

        {
            _ingredientItemLogic = ingredientItemLogic;
        }

        public int InsertIngredient(IngredientItem ingredientItem)
        {
            return _ingredientItemLogic.InsertIngredient(ingredientItem);
        }

        List<IngredientItem> IIngredientItemService.GetIngredients()
        {
            return _ingredientItemLogic.GetIngredients();
        }
    }
}