using API.Attributes;
using API.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Resources.FilterModels;
using Resources.RequestModels;
using Security.IServices;
using System;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserSecurityService _userSecurityService;
        private readonly IUserService _userService;

        public UserController(IUserSecurityService userSecurityService, IUserService userService)
        {
            _userSecurityService = userSecurityService;
            _userService = userService;
        }

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpPost(Name = "LoginUser")]
        public string Login([FromBody] LoginRequest loginRequest)
        {

            return _userSecurityService.GenerateAuthorizationToken(loginRequest.UserName, loginRequest.UserPassword);
        }

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpPost(Name = "InsertUser")]
        public int InsertUser([FromBody] NewUserRequest newUserRequest)
        {
            return _userService.InsertUser(newUserRequest);
        }

        [EndpointAuthorize(AllowedUserRols = "Administrador, Operario")]
        [HttpGet(Name = "GetAllUsers")]
        public List<UserItem> GetAll()
        {
            return _userService.GetAllUsers();
        }

        [EndpointAuthorize(AllowedUserRols = "Administrador")]
        [HttpPatch(Name = "ModifyUser")]
        public void Patch([FromBody] UserItem userItem)
        {
            _userService.UpdateUser(userItem);
        }

        [EndpointAuthorize(AllowedUserRols = "Administrador")]
        [HttpDelete(Name = "DeleteUser")]
        public void Delete([FromQuery] int id)
        {
            _userService.DeleteUser(id);
        }

        [EndpointAuthorize(AllowedUserRols = "Administrador")]
        [HttpGet(Name = "GetUsersByCriteria")]
        public List<UserItem> GetByCriteria([FromQuery] UserFilter userFilter)
        {
            return _userService.GetUsersByCriteria(userFilter);
        }
    }
}
