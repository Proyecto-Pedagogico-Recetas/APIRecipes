using API.IServices;
using Data;
using Entities.Entities;
using Logic.Ilogic;
using Logic.Logic;

namespace API.Services
{
    public class CategoryItemService : ICategoryItemService
    {
        private readonly ICategoryItemLogic _categoryItemLogic;

        public CategoryItemService(ICategoryItemLogic categoryItemLogic)
        {
            _categoryItemLogic = categoryItemLogic;
        }
        public List<CategoryItem> GetCategories()
        {
           return _categoryItemLogic.GetCategories();
        }

        public int InsertCategory(CategoryItem categoryItem)
        {
            return _categoryItemLogic.InsertCategory(categoryItem);
        }

        public void DeleteCategory(int id)
        {
            _categoryItemLogic.DeleteCategory(id);
        }
    }
}
