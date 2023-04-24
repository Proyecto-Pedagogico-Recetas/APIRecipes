using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IIngredientItemService
    {

        List<AlergenItem> GetAlergens();

        int InsertAlergen(AlergenRequest alergenRequest);

    }
}