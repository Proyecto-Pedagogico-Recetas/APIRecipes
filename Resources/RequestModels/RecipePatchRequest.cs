using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.RequestModels
{
    public class RecipePatchRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Instructions { get; set; }
        //public int Category { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
        public string? Observations { get; set; }
        public string? Materials { get; set; }
        public List<IngredientRequest> Ingredients { get; set; }
        public List<AlergenRequest> Alergens { get; set; }
    }
}
