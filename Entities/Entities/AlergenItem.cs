using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class AlergenItem
    {

        public AlergenItem() 
        { 
            IsActive= true;
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public bool IsActive { get; set; }


    }

   
}
