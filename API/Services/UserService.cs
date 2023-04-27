using API.IServices;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.AspNetCore.Identity;
using Resources.FilterModels;
using Resources.RequestModels;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserLogic _userLogic;
        private readonly IUserSecurityLogic _userSecurityLogic;
        public UserService(IUserLogic userLogic, IUserSecurityLogic userSecurityLogic)
        {
            _userLogic = userLogic;
            _userSecurityLogic = userSecurityLogic;
        }

        public void DeleteUser(int id)
        {
            _userLogic.DeleteUser(id);
        }

        public List<UserItem> GetAllUsers()
        {
            return _userLogic.GetAllUsers();
        }

        public List<UserItem> GetUsersByCriteria(UserFilter userFilter)
        {
            return _userLogic.GetUsersByCriteria(userFilter);
        }

        public int InsertUser(NewUserRequest newUserRequest)
        {
            var newUserItem = newUserRequest.ToUserItem();
            newUserItem.EncryptedPassword = _userSecurityLogic.HashString(newUserRequest.Password);
            return _userLogic.InsertUser(newUserItem);
        }

        public void UpdateUser(UserItem userItem)
        {
            _userLogic.UpdateUser(userItem);
        }

        // Creamos una nueva clase y Validamos elementos de la clase UserItem
        public int InsertUserFromRequest(NewUserRequest request)
        {
            var newUserItem = request.ToUserItem();
            //var newUserItem = new UserItem();
            if (!ValidateUser(newUserItem))
            {
                throw new InvalidDataException();
            }
            _userLogic.InsertUser(newUserItem);
            if (!ValidateInsertedUser(newUserItem))
            {
                throw new InvalidOperationException();
            }
            return newUserItem.Id;
        }
        // Creamos una nueva clase y Validamos elementos de la clase UserItem
        public static bool ValidateUser(UserItem userItem)
        {
            if (userItem == null)
            {
                return false;
            }
            if (userItem.UserName == null || userItem.UserName == "")
            {
                return false;
            }
            if (userItem.UserEmail == null || userItem.UserEmail == "")
            {
                return false;
            }
            if (userItem.InsertDate > DateTime.Now)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateInsertedUser(UserItem userItem)
        {
            if (!ValidateUser(userItem))
            {
                return false;
            }
            if (userItem.Id < 1)
            {
                return false;
            }
            {
                return true;
            }
        }

        public static object ValidateUserA(UserItem userA)
        {
            throw new NotImplementedException();
        }
    }
}
