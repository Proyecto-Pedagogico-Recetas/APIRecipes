using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface ICategoryItemService
    {

        List<CategoryItem> GetCategories();
    }
}
