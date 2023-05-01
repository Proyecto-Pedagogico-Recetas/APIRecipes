using API.IServices;
using Data.Migrations;
using Entities.Entities;
using Logic.Ilogic;
using Logic.Logic;
using Resources.RequestModels;

namespace API.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemLogic _orderItemLogic;

        public OrderItemService(IOrderItemLogic orderItemLogic)
        {
            _orderItemLogic = orderItemLogic;
        }
        public List<OrderItem> GetOrders()
        {
            return _orderItemLogic.GetOrders();
        }

        public async Task<OrderItem> InsertOrder(OrderRequest orderRequest)
        {
            return await _orderItemLogic.InsertOrder(orderRequest);
        }

        // Creamos una nueva clase y Validamos elementos de la clase OrderItem
        public bool ValidateOrder(OrderItem orderItem)
        {
            
            if (orderItem.Id < 1)
            {
                return false;
            }

            if (orderItem.IdUser < 1)
            {
                return false;
            }
            if (orderItem.IdIngredient < 1)
            {
                return false;
            }
            if (orderItem.Amount < 1)
            {
                return false;
            }
            //if (orderItem.Unit < 1)
            //{
            //    return false;
            //}
            if (orderItem.InsertDate > DateTime.Now)
            {
                return false;
            }
            return true;


        }
       
        public bool ValidateInsertedOrder(OrderItem orderItem)
        {
            if (!ValidateOrder(orderItem))
            {
                return false;
            }
            if (orderItem.Id < 1)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateOrderA(OrderItem orderItem)
        {
            if (orderItem.Id < 1)
            {
                return false;
            }

            if (orderItem.IdUser < 1)
            {
                return false;
            }
            if (orderItem.IdIngredient < 1)
            {
                return false;
            }
            if (orderItem.Amount < 1)
            {
                return false;
            }
            //if (orderItem.Unit < 1)
            //{
            //    return false;
            //}
            if (orderItem.InsertDate > DateTime.Now)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateInsertedOrderA(OrderItem orderItem)
        {
            if (!ValidateOrderA(orderItem))
            {
                return false;
            }
            if (orderItem.Id < 1)
            {
                return false;
            }
            return true;
        }
    }
}
