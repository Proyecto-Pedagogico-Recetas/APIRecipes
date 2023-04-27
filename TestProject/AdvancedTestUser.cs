using API.Services;
using Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Diagnostics.Metrics;
using TestProject.SampleData;

namespace TestProject.SampleData
{
    [TestClass]
   
    public class AdvancedTestUser
    {
        private readonly UserService _userService;
        private List<UserItem> AddedUserList = new List<UserItem>();
        private int IdCounter = 0;
        public AdvancedTestUser()
        {
            var mockContextOptions = new DbContextOptions<ServiceContext>();
            var mockServiceContext = new Mock<ServiceContext>(mockContextOptions);
            var mockUserSet = new Mock<DbSet<UserItem>>();
            var mockEmail = new Mock<IEmailService>();

            mockServiceContext.Setup(m => m.SaveChanges())
                                        .Callback(() =>
                                        {
                                            if (AddedUserList.Count > 0)
                                            {
                                                foreach (var order in AddedUserList)
                                                {
                                                    order.Id = IdCounter + 1;
                                                    IdCounter++;
                                                }
                                                AddedUserList = new List<UserItem>();
                                            }
                                        });

            mockUserSet.Setup(m => m.Add(It.IsAny<UserItem>()))
                                       .Callback((UserItem userItem) =>
                                       {
                                           AddedUserList.Add(userItem);
                                       });

            mockEmail.Setup(m => m.SendNewUserNotification(It.IsAny<UserItem>()));

            var contextObject = mockServiceContext.Object;
            contextObject.Users = mockUserSet.Object;
            _userService = new UserService(contextObject, mockEmail.Object);
        }
        [TestMethod]
        public void ValidateUserTest()
        {
            //Arrange
            var validUser = UserSampleData.ValidUserData;
            var invalidUser = UserSampleData.InvalidData;

            //Act and Assert
            var counter = 1;
            foreach (var user in validUser)
            {
                Assert.AreEqual(user.IsValid, _userService.ValidateUser(user), "Error en la iteración nro " + counter.ToString());
                counter++;
            }
            foreach (var user in invalidUser)
            {
                Assert.AreEqual(user.IsValid, _userService.ValidateUser(user), "Error en la iteración nro " + counter.ToString());
                counter++;
            }
        }
    }
}