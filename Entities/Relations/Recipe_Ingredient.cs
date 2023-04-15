using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Relations
{
    public class Recipe_Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int IngredientId { get; set; }
        public string RecipeName { get; set; }
        public int RecipeId { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }

        [JsonIgnore]
        public virtual RecipeItem Recipes { get; set; }
        [JsonIgnore]
        public virtual IngredientItem Ingredients { get; set; }
    }
}
