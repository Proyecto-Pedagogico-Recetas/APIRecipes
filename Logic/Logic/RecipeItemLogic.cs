using Data;
using Entities.Entities;
using Logic.Ilogic;
using Logic.Logic;

namespace Logic.Logic
{
    public class RecipeItemLogic : BaseContextLogic, IRecipeItemLogic
    {
        public RecipeItemLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public int InsertRecipe(RecipeItem recipeItem)
        {

            _serviceContext.Recipes.Add(recipeItem);
            _serviceContext.SaveChanges();
            return recipeItem.Id;
        }
    }
}

