﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class CategoryItem
    {
        public CategoryItem() 
        {
            IsActive= true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public virtual ICollection<RecipeItem> Recipes { get; set; }
    }
}
