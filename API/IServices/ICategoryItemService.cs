using Data;
using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface ICategoryItemService
    {
        List<CategoryItem> GetCategories();
        int InsertCategory(CategoryItem categoryItem);
        public void DeleteCategory(int id);
      
    }
}
