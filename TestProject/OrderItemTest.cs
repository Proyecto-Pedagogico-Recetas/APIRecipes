using API.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class OrderItemTest
    {
        [TestMethod]
        public void ValidateOrderTest()
        {
            //Arrange
            var orderA = new OrderItem();
            orderA.Id = 1;
            orderA.IdUser = 2;
            orderA.IdIngredient = 3;
            orderA.Amount = 5;
            //orderA.Unit = 4;
            orderA.InsertDate = DateTime.Now.AddDays(-1);

            var orderB = new OrderItem();
            orderB.Id = 2;
            orderB.IdUser = 3;
            orderB.IdIngredient = 4;
            orderB.Amount = 10;
            //orderB.Unit = 1;
            orderB.InsertDate = DateTime.Now.AddDays(-2);

            var orderC = new OrderItem();
            orderC.Id = 3;
            orderC.IdUser = 4;
            orderC.IdIngredient = 5;
            orderC.Amount = 3;
            //orderC.Unit = 3;
            orderC.InsertDate = DateTime.Now.AddDays(-3);

            //Act
            var isValidA = OrderItemService.ValidateOrderA(orderA);
            var isValidB = OrderItemService.ValidateOrderA(orderB);
            var isValidC = OrderItemService.ValidateOrderA(orderC);

            //Assert
            Assert.AreEqual(true, isValidA, "El test de modelo de OrderItem A ha fallado.");
            Assert.AreEqual(true, isValidB, "El test de modelo de OrderItem B ha fallado.");
            Assert.AreEqual(true, isValidC, "El test de modelo de OrderItem C ha fallado.");
        }
    }
}


