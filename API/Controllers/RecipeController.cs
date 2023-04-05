using API.IServices;
using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class RecipeController : ControllerBase
    {

        private readonly IRecipeItemService _recipeItemService;
        private readonly ServiceContext _serviceContext;

        public RecipeController(IRecipeItemService recipeItemService, ServiceContext serviceContext)
        {
            _recipeItemService = recipeItemService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertImage")]
        public int Post([FromBody] RecipeItem recipeItem)
        {

            return _recipeItemService.InsertRecipe(recipeItem);
        }

        //[HttpDelete(Name = "DeleteImage")]
        //public void Delete([FromQuery] int Id)
        //{

        //    _imageService.DeleteImage(Id);

        //}

        //[HttpPatch(Name = "ModifyImage")]
        //public void Patch([FromBody] ImageItem imageItem)

        //{
        //    _imageService.UpdateImage(imageItem);

        //}

        //[HttpGet(Name = "GetImagesByCriteria")]
        //public List<ImageItem> GetImageByCriteria([FromQuery] string Category)
        //{

        //    return _imageService.GetImageByCriteria(Category);
        //}

        //[HttpGet(Name = "GetAllImages")]
        //public List<ImageItem> GetAll()
        //{

        //    return _imageService.GetAll();

    }    //}
}