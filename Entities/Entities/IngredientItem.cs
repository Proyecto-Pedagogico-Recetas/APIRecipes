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
    public class IngredientItem
    {
        public int Id { get; set; }
        public string Ingredient { get; set; }

        [JsonIgnore]
        public virtual ICollection<Recipe_Ingredient> Ingredients { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderItem> Order { get; set; }

    }
}
