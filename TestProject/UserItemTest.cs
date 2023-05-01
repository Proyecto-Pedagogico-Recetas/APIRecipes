using API.Services;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class UserItemTest
    {
        [TestMethod]
        public void ValidateUserTest()
        {
            //Arrange
            var userA = new UserItem();
            userA.Id = 1;
            userA.IdRol = 2;
            userA.UserName = "Juanlu";
            userA.UserEmail = "juanlu@example.com";
            userA.UserPhone = 1234567;
            userA.InsertDate = DateTime.Now.AddDays(-1);
            userA.IsActive = true;
            userA.EncryptedPassword = "encrypted_password";
            userA.EncryptedToken = "encrypted_token";
            userA.TokenExpireDate = DateTime.Now.AddDays(7);
            userA.Password = "password";


            var userB = new UserItem();
            userB.Id = 2;
            userB.IdRol = 3;
            userB.UserName = "Anyi";
            userB.UserEmail = "anyi@example.com";
            userB.UserPhone = 123456789;
            userB.InsertDate = DateTime.Now.AddDays(-1);
            userB.IsActive = true;
            userB.EncryptedPassword = "encrypted_password";
            userB.EncryptedToken = "encrypted_token";
            userB.TokenExpireDate = DateTime.Now.AddDays(7);
            userB.Password = "password";

            var userC = new UserItem();
            userC.Id = 3;
            userC.IdRol = 2;
            userC.UserName = "Celia";
            userC.UserEmail = "celia@example.com";
            userC.UserPhone = 123456789;
            userC.InsertDate = DateTime.Now.AddDays(-1);
            userC.IsActive = true;
            userC.EncryptedPassword = "encrypted_password";
            userC.EncryptedToken = "encrypted_token";
            userC.TokenExpireDate = DateTime.Now.AddDays(7);
            userC.Password = "password";


            //Act
            var isValidA = UserService.ValidateUser(userA);
            var isValidB = UserService.ValidateUser(userB);
            var isValidC = UserService.ValidateUser(userC);


            //Assert

            Assert.AreEqual(true, isValidA, "El testede modelo de UserA ha fallado.");
            Assert.AreEqual(true, isValidB, "Custom error message");
            Assert.AreEqual(true, isValidC, "Custom error message");


        }
    }

}