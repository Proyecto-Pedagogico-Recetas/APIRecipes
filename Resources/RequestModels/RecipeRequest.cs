
using Entities.Entities;
using Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.RequestModels
{
    public class RecipeRequest
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int Category { get; set; }
        public string Author { get; set; }
        public List<IngredientRequest> Ingredients { get; set; }
        public List<AlergenItem> Alergens { get; set; }

        public RecipeItem ToRecipeItem()
        {
            var recipeItem = new RecipeItem();

            recipeItem.IsPublic = true;
           recipeItem.IsActive = true;
            recipeItem.InsertDate = DateTime.Now;
            return recipeItem;
        }

        //public List<AlergenItem> ToListAlergens()
        //{
        //    return ServiceContext.
        //}

    }
    
}
