using API.IServices;
using Entities.Entities;
using Logic.Ilogic;
using Logic.Logic;
using Resources.RequestModels;

namespace API.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemLogic _orderItemLogic;

        public OrderItemService(IOrderItemLogic orderItemLogic)
        {
            _orderItemLogic = orderItemLogic;
        }
        public List<OrderItem> GetOrders()
        {
           return _orderItemLogic.GetOrders();
        }

        public async Task<OrderItem> InsertOrder(OrderRequest orderRequest)
        {
            return await _orderItemLogic.InsertOrder(orderRequest);
        }
    }
}
