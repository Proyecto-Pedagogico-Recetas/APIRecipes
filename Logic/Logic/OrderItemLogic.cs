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
        public OrderItemLogic (ServiceContext serviceContext) : base(serviceContext) { }



        public List<OrderItem>GetOrders()
        {
            return _serviceContext.Orders.ToList();
        }

        public async Task<OrderItem> InsertOrder(OrderRequest orderRequest)
        {

            //var user = _serviceContext.Users.FirstOrDefaultAsync(u => u.UserName == orderRequest.User);
            //var ingredient = _serviceContext.Ingredients.FirstOrDefaultAsync(i => i.Ingredient == orderRequest.Ingredient);

            var user = await _serviceContext.Users.FirstOrDefaultAsync(u => u.UserName == orderRequest.User);
            var ingredient = await _serviceContext.Ingredients.FirstOrDefaultAsync(i => i.Ingredient == orderRequest.Ingredient);


            var newOrder =new OrderItem
            {
                IdUser = user.Id,
                IdIngredient = ingredient.Id,
                Amount = orderRequest.Amount,
                Unit = orderRequest.Unit,
                User = user,
                Ingredient = ingredient,

            };

            _serviceContext.Orders.Add(newOrder);
            await _serviceContext.SaveChangesAsync();

            return newOrder;



            // Buscar el usuario correspondiente al nombre recibido en la solicitud
            //var user = await _serviceContext.Users.FirstOrDefaultAsync(u => u.Name == orderRequest.User);

            // Crear una nueva instancia de OrderItem y establecer la propiedad IdUser con el Id del usuario encontrado
            //var newOrder = new OrderItem
            //{
            //IdUser = user.Id,
            // Otras propiedades de OrderItem
            //};

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