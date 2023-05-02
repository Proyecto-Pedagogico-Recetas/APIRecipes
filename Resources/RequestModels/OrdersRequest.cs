using Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.RequestModels
{
    public class OrdersRequest
    {
        //public string User { get; set; }
        //public string Ingredient { get; set; }
        //public decimal Amount { get; set; }
        //public string Unit { get; set; }

        //ATRIBUTOS COMUNES DE LA SOLICITUD COMO TAL Y ESOS SI VAN ACÀ
        public List<OrderItem> OrderItems { get; set; }
            //= new List<OrderItem>();
      
    }
}

