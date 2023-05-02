using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class OrderItem
    {
        public OrderItem()
        {
            IsActive = true;
            InsertDate = DateTime.Now;

        }
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int Username { get; set; }
        public int IdIngredient { get; set; }
        public string IngredientName { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public DateTime InsertDate { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public virtual UserItem User { get; set; }
        [JsonIgnore]
        public virtual IngredientItem Ingredient { get; set; }

    }
}