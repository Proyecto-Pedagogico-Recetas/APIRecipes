using API.IServices;
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
    }
}
