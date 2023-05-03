using Data;
using Entities.Entities;
using Entities.Relations;
using Logic.Ilogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Resources.RequestModels;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Logic.Logic
{
    public class OrderItemLogic : BaseContextLogic, IOrderItemLogic
    {
        public OrderItemLogic(ServiceContext serviceContext) : base(serviceContext) { }



        public List<List<OrderItem>> GetOrders()
        {
            var ordersByUser = _serviceContext.Orders.GroupBy(o => o.IdUser).ToList();
            return ordersByUser.Select(o => o.ToList()).ToList();
        }


        public async Task InsertOrders(OrdersRequest ordersRequest)
        {

            await _serviceContext.Orders.AddRangeAsync(ordersRequest.OrderItems);
            _serviceContext.SaveChanges();

            //var newOrders = new List<OrderItem>();

            //foreach (var item in newOrders)
            //{ 
            //    //{
            //    //var orderData = new OrderItem
            //    //foreach (var item in orderData)
            //    //    {
            //    //       

            //    var userId = item.IdUser;
            //    var ingredientId = item.IdIngredient;
            //    var newOrder = new OrderItem
            //        {
            //            IdUser = userId,
            //            IdIngredient = ingredientId,
            //            Amount = item.Amount,
            //            Unit = item.Unit,
            //            IngredientName = item.IngredientName,
            //            Username= item.Username,
            //        };
            //         newOrders.Add(newOrder);
            //        _serviceContext.Orders.Add(newOrder);
            //        await _serviceContext.SaveChangesAsync();

            //    //}



            //var newOrders = new List<OrderItem>();

            //foreach (var item in ordersRequest.OrderItems)
            //{
            //    //{
            //    //var orderData = new OrderItem
            //    //foreach (var item in orderData)
            //    //    {
            //    //       

            //    var userId = item.IdUser;
            //    var ingredientId = item.IdIngredient;
            //    var newOrder = new OrderItem
            //    {
            //        IdUser = userId,
            //        IdIngredient = ingredientId,
            //        Amount = item.Amount,
            //        Unit = item.Unit,
            //        IngredientName = item.IngredientName,
            //        Username = item.Username,
            //    };
            //    //newOrders.Add(newOrder);
            //    _serviceContext.Orders.Add(newOrder);
            //    _serviceContext.SaveChanges();

                //}
            }


        }
    }

     




//var recipeData =  _serviceContext.Set<RecipeItem>().ToList();
//var alergens = _serviceContext.Set<Recipe_Alergen>().Where

//foreach (var recipe in recipeData) 
//{
//  recipeRequest.Name= recipe.Name;
//  recipeRequest.Alergens = 
//}





//{
//    List<RecipeItem> recipes;
//    using (var context = new ServiceContext(Recipe))
//    {
//        recipes = _serviceContext.Recipes
//            .Include(r => r.Category)

//            .ToList();
//    }
//    return recipes;
//}