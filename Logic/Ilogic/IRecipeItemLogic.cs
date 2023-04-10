using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IRecipeItemLogic
    {
        int InsertRecipe(RecipeItem recipeItem);
        void DeleteRecipe(int id);
    }
}
