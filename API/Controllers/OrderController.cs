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
        //public async Task<OrderItem> InsertOrder([FromBody] OrderRequest orderRequest);
         public async Task<IEnumerable<OrderItem>> InsertOrder([FromBody]IEnumerable<OrderRequest> orderRequests)
        {

            return await _orderItemService.InsertOrder(orderRequests);
        }

        ////[EndpointAuthorize(AllowedUserRols = "Administrador")]
        //[EndpointAuthorize(AllowsAnonymous = true)]
        //[HttpDelete(Name = "DeleteRecipe")]
        //public void Delete([FromQuery] int Id)
        //{

        //    _recipeItemService.DeleteRecipe(Id);

        //}




        //[EndpointAuthorize(AllowedUserRols = "Administrador")]
        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpGet(Name = "GetAllOrders")]
        public List<List<OrderItem>> GetOrders()
        {

            return _orderItemService.GetOrders();
        }





        //[HttpPatch(Name = "ModifyImage")]
        //public void Patch([FromBody] ImageItem imageItem)

        //{
        //    _imageService.UpdateImage(imageItem);

        //}


        //[HttpGet(Name = "GetAllImages")]
        //public List<ImageItem> GetAll()
        //{

        //    return _imageService.GetAll();

    }    //}
}