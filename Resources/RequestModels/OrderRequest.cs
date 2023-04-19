using Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.RequestModels
{
    public class OrderRequest
    {


        public string User { get; set; }
        public string Ingredient { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }


    }
}

