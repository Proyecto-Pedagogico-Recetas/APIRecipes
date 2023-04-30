using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IAlergenItemService
    {
        List<AlergenItem> GetAlergens();
        int InsertAlergen(AlergenRequest alergenRequest);
        void DeleteAlergen(int id);
    }
}
