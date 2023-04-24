using API.IServices;
using Entities.Entities;
using Logic.Ilogic;
using Logic.Logic;
using Resources.RequestModels;

namespace API.Services
{
    public class AlergenItemService : IIngredientItemService
    {
        private readonly IAlergenItemLogic _alergenItemLogic;

        public AlergenItemService(IAlergenItemLogic alergenItemLogic)
        {
            _alergenItemLogic = alergenItemLogic;
        }
        public List<AlergenItem> GetAlergens()
        {
            return _alergenItemLogic.GetAlergens();
        }


        int IIngredientItemService.InsertAlergen(AlergenRequest alergenRequest)
        {
            return _alergenItemLogic.InsertAlergen(alergenRequest);
        }
    }
}