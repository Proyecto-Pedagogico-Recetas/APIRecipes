using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class RecipeItem
    {
        public RecipeItem() 
        { 
            IsActive= true;
            InsertDate= DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public string Author { get; set; }
        public bool IsActive { get; private set; }
        public bool IsPublic { get; set; }
        public DateTime InsertDate { get; private set; }
    }
}
