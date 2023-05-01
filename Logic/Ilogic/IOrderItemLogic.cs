using Entities.Entities;
using Resources.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IOrderItemLogic
    {
        public List<List<OrderItem>> GetOrders();
        public Task<IEnumerable<OrderItem>>InsertOrder(IEnumerable<OrderRequest> orderRequests);
    }
}