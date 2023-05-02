using API.Attributes;
using API.IServices;
using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resources.RequestModels;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderItemService _orderItemService;
        private readonly ServiceContext _serviceContext;

        public OrderController(IOrderItemService orderItemService, ServiceContext serviceContext)
        {
            _orderItemService = orderItemService;
            _serviceContext = serviceContext;

        }

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpPost(Name = "InsertOrder")]
         //public async Task<IEnumerable<OrderItem>> InsertOrder([FromBody]IEnumerable<OrderRequest> orderRequests)
         public async Task InsertOrders([FromBody] OrdersRequest ordersRequest)
        {

            _orderItemService.InsertOrders(ordersRequest);
        }

        //[EndpointAuthorize(AllowedUserRols = "Administrador")]
        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpGet(Name = "GetAllOrders")]
        public List<List<OrderItem>> GetOrders()
        {

            return _orderItemService.GetOrders();
        }
    }    
}