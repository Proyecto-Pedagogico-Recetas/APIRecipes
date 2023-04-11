using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.RequestModels
{
    public class IngredientRequest
    {
        public string Ingredient { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
    }
}
