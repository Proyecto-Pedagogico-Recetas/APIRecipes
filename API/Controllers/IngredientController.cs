//using API.Attributes;
//using API.IServices;
//using Data;
//using Entities.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Resources.RequestModels;
//using System.Web.Http.Cors;

//namespace API.Controllers
//{
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    [Route("[controller]/[action]")]
//    public class IngredientController : ControllerBase
//    {

//        private readonly IIngredientItemService _ingredientItemService;
//        private readonly ServiceContext _serviceContext;

//        public IngredientController(IIngredientItemService ingredientItemService, ServiceContext serviceContext)
//        {
//            _ingredientItemService = ingredientItemService;
//            _serviceContext = serviceContext;

//        }

//        [EndpointAuthorize(AllowsAnonymous = true)]
//        [HttpPost(Name = "InsertIngredient")]
//        public int Post([FromBody] IngredientRequest ingredientRequest)
//        {

//            return _ingredientItemService.InsertIngredient(ingredientRequest);
//        }

//        ////[EndpointAuthorize(AllowedUserRols = "Administrador")]
//        //[EndpointAuthorize(AllowsAnonymous = true)]
//        //[HttpDelete(Name = "DeleteRecipe")]
//        //public void Delete([FromQuery] int Id)
//        //{

//        //    _recipeItemService.DeleteRecipe(Id);

//        //}

//        //[EndpointAuthorize(AllowedUserRols = "Administrador")]
//        [EndpointAuthorize(AllowsAnonymous = true)]
//        [HttpGet(Name = "GetAllIngredients")]
//        public List<IngredientItem> GetIngredients()
//        {

//            return _ingredientItemService.GetIngredients();
//        }

//        //[HttpPatch(Name = "ModifyImage")]
//        //public void Patch([FromBody] ImageItem imageItem)

//        //{
//        //    _imageService.UpdateImage(imageItem);

//        //}


//        //[HttpGet(Name = "GetAllImages")]
//        //public List<ImageItem> GetAll()
//        //{

//        //    return _imageService.GetAll();

//    }    //}
//}