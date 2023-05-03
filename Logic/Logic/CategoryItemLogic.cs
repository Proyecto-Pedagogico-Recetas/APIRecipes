using Data;
using Entities.Entities;
using Entities.Relations;
using Logic.Ilogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Resources.RequestModels;
 using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Logic.Logic
{
    public class CategoryItemLogic : BaseContextLogic, ICategoryItemLogic
    {
        public CategoryItemLogic(ServiceContext serviceContext) : base(serviceContext) { }



        public List<CategoryItem>GetCategories()
        {



            return _serviceContext.Categories
                     .Where(p => p.IsActive == true).ToList(); 

        }

        public int InsertCategory(CategoryItem categoryItem)
        {

            var newCategory = new CategoryItem
            {
                Id = categoryItem.Id,
                Name = categoryItem.Name,
                Image= categoryItem.Image,
            };

            _serviceContext.Categories.Add(newCategory);
            _serviceContext.SaveChanges();
            return newCategory.Id;
        }

        public void DeleteCategory(int id)
        {
            var categoryToDelete = _serviceContext.Set<CategoryItem>()
                  .Where(r => r.Id == id).First();

            categoryToDelete.IsActive = false;

            _serviceContext.SaveChanges();
        }
    }
}



//var recipeData =  _serviceContext.Set<RecipeItem>().ToList();
//var alergens = _serviceContext.Set<Recipe_Alergen>().Where

//foreach (var recipe in recipeData) 
//{
//  recipeRequest.Name= recipe.Name;
//  recipeRequest.Alergens = 
//}





//{
//    List<RecipeItem> recipes;
//    using (var context = new ServiceContext(Recipe))
//    {
//        recipes = _serviceContext.Recipes
//            .Include(r => r.Category)

//            .ToList();
//    }
//    return recipes;
//}