﻿using API.Attributes;
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

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpPost(Name = "InsertCategory")]
        public int Post([FromBody] CategoryItem categoryItem)
        {

            return _categoryItemService.InsertCategory(categoryItem);
        }

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpDelete(Name = "DeleteCategory")]
        public void Delete([FromQuery] int Id)
        {

            _categoryItemService.DeleteCategory(Id);

        }

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpGet(Name = "GetAllCategories")]
        public List<CategoryItem> GetCategories()
        {

            return _categoryItemService.GetCategories();
        }
    }    
}