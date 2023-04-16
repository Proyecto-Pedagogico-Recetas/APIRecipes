using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Relations
{
    public class Recipe_Alergen
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int AlergenId { get; set; }
        public string AlergenName { get; set; }
        [JsonIgnore]
        public virtual RecipeItem Recipes { get; set; }
        [JsonIgnore]
        public virtual AlergenItem Alergens { get; set; }
    }
}