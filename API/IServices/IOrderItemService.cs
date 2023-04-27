using Entities.Entities;
using Resources.RequestModels;

namespace API.IServices
{
    public interface IOrderItemService
    {

        List<OrderItem> GetOrders();

        public Task<IEnumerable<OrderItem>> InsertOrder(IEnumerable<OrderRequest> orderRequests);

    }
}