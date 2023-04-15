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
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryItemService _categoryItemService;
        private readonly ServiceContext _serviceContext;

        public CategoryController(ICategoryItemService categoryItemService, ServiceContext serviceContext)
        {
            _categoryItemService = categoryItemService;
            _serviceContext = serviceContext;

        }

        //[EndpointAuthorize(AllowsAnonymous = true)]
        //[HttpPost(Name = "InsertRecipe")]
        //public int Post([FromBody] RecipeRequest recipeRequest)
        //{

        //    return _recipeItemService.InsertRecipe(recipeRequest);
        //}

        ////[EndpointAuthorize(AllowedUserRols = "Administrador")]
        //[EndpointAuthorize(AllowsAnonymous = true)]
        //[HttpDelete(Name = "DeleteRecipe")]
        //public void Delete([FromQuery] int Id)
        //{

        //    _recipeItemService.DeleteRecipe(Id);

        //}

        //[EndpointAuthorize(AllowedUserRols = "Administrador")]
        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpGet(Name = "GetAllCategories")]
        public List<CategoryItem> GetCategories()
        {

            return _categoryItemService.GetCategories();
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