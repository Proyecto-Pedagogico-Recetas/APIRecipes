using Entities.Entities;
using Resources.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IRecipeItemLogic
    {
        public Task InsertRecipe(RecipeRequest recipeRequest);
        void DeleteRecipe(int id);
        public  Task<RecipeItem> GetRecipe(int recipeId);
        public Task<List<RecipeItem>> GetAllRecipes();
        public void UpdateRecipe(int id, RecipePatchRequest recipePatchRequest);
    }
}
