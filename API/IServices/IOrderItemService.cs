using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IOrderItemService
    {
        List<List<OrderItem>> GetOrders();
        public Task InsertOrders(OrdersRequest ordersRequest);
    }
}