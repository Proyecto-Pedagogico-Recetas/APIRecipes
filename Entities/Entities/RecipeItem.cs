using Entities.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class RecipeItem
    {
        public RecipeItem()
        {
            IsActive = true;
            IsPublic= true;
            InsertDate = DateTime.Now;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        //public List<IngredientItem> Ingredients { get; set; }
        //public virtual List<Ingredient> Ingredientes {get; set;}
        public int Category { get; set; }
        public string? Author { get; set; }
        public string? Observations { get; set; }
        public string? Materials { get; set; }
        //public List<AlergenItem> Alergens
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }
        public DateTime InsertDate { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Recipe_Alergen> Alergens { get; set; }


    }
}
