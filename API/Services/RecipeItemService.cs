using API.IServices;
using Entities.Entities;
using Entities.Relations;
using Logic.Ilogic;
using Resources.RequestModels;

namespace API.Services
{
    public class RecipeItemService : IRecipeItemService
    {
        private readonly IRecipeItemLogic _recipeItemLogic;

        public RecipeItemService(IRecipeItemLogic recipeItemLogic)
        {
            _recipeItemLogic = recipeItemLogic;
        }

        public int InsertRecipe(RecipeRequest recipeRequest)
        {
            return _recipeItemLogic.InsertRecipe(recipeRequest);

        }

        public void DeleteRecipe(int id)
        {
            _recipeItemLogic.DeleteRecipe(id);
        }

        public async Task<RecipeItem> GetRecipe(int recipeId)
        {
            return await _recipeItemLogic.GetRecipe(recipeId);
        }

        public List<RecipeItem> GetAllRecipes()
        {
            return _recipeItemLogic.GetAllRecipes();
        }

        // Creamos una nueva clase y Validamos elementos de la clase RecipeItem
        public int InsertRecipeItem(RecipeRequest recipeRequest)
        {
            var RecipeItem = recipeRequest.ToRecipeItem();
            if (!ValidateRecipe(RecipeItem))
            {
                throw new InvalidDataException();
            }
            RecipeItem.InsertDate = DateTime.Now;
            _recipeItemLogic.InsertRecipe(RecipeItem);
            if (!ValidateInsertedRecipe(RecipeItem))
            {
                throw new InvalidOperationException();
            }
            return RecipeItem.Id;
        }

        // Validamos elementos de la clase RecipeItem
        public static bool ValidateRecipe(RecipeItem recipeItem)
        {
            if (recipeItem == null)
            {
                return false;
            }
            if (recipeItem.Id < 1)
            {
                return false;
            }
            if (recipeItem.Name == null || recipeItem.Name == "")
            {
                return false;
            }
            if (recipeItem.Category < 1)
            {
                return false;
            }
            if (recipeItem.PostedBy < 1)
            {
                return false;
            }
            if (recipeItem.InsertDate > DateTime.Now)
            {
                return false;
            }
            if (recipeItem.Ingredients == null || recipeItem.Ingredients.Count == 0)
            {
                return false;
            }
                return true;
            }

            public static bool ValidateInsertedRecipe(RecipeItem recipeItem)
            {
                if (!ValidateRecipe(recipeItem))
                {
                    return false;
                }
                if (recipeItem.Id < 1)
                {
                    return false;
                }
                return true;
            }

    }
}

