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
    public class AlergenItemLogic : BaseContextLogic, IAlergenItemLogic
    {
        public AlergenItemLogic (ServiceContext serviceContext) : base(serviceContext) { }



        public List<AlergenItem>GetAlergens()
        {



            return _serviceContext.Alergens.ToList();




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