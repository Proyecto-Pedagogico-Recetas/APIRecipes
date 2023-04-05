using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Relations
{
    public class Recipe_Alergen
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int AlergenId { get; set; }
    }
}
