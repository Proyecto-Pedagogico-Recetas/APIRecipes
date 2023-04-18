using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IOrderItemService
    {

        List<OrderItem> GetOrders();

        Task<OrderItem> InsertOrder(OrderRequest orderRequest);

    }
}
