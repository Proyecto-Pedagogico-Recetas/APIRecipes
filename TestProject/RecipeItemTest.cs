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
    public class RecipeItemTest
    {
        [TestMethod]
        public void ValidateRecipeTest()
        {
            // Arrange
            var recipeA = new RecipeItem();
            recipeA.Id = 1;
            recipeA.Name = "Timbal de verduras con queso de cabra";
            recipeA.Instructions = "1. Asaremos las verduras a fuego directo para que cojan sabor ahumado. 2. Prepara las tortillas. 3. Agrega el pollo a las tortillas. 4. Añade tus ingredientes favoritos.";
            recipeA.Category = 2;
            recipeA.Author = "Juan";
            recipeA.Observations = "Para una versión más saludable, utiliza ingredientes frescos.";
            recipeA.Materials = "Pimiento rojo, Pimiento verde, Berenjena";
            recipeA.PostedBy = 3;
            recipeA.IsActive = true;
            recipeA.IsPublic = true;
            recipeA.InsertDate = DateTime.Now.AddDays(-1);

            var recipeB = new RecipeItem();
            recipeB.Id = 2;
            recipeB.Name = "";
            recipeB.Instructions = "1. Cocina el pollo. 2. Prepara las tortillas. 3. Agrega el pollo a las tortillas. 4. Añade tus ingredientes favoritos.";
            recipeB.Category = 3;
            recipeB.Author = "Juan Perez";
            recipeB.Observations = "Para una versión más saludable, utiliza tortillas integrales.";
            recipeB.Materials = "Pollo, tortillas, lechuga, tomate, cebolla, queso";
            recipeB.PostedBy = 3;
            recipeB.IsActive = true;
            recipeB.IsPublic = true;
            recipeB.InsertDate = DateTime.Now.AddDays(-1);

            var recipeC = new RecipeItem();
            recipeC.Id = 1;
            recipeC.Name = "Tacos de pollo";
            recipeC.Instructions = "1. Cocina el pollo. 2. Prepara las tortillas. 3. Agrega el pollo a las tortillas. 4. Añade tus ingredientes favoritos.";
            recipeC.Category = 2;
            recipeC.Author = "Juan Perez";
            recipeC.Observations = "Para una versión más saludable, utiliza tortillas integrales.";
            recipeC.Materials = "Pollo, tortillas, lechuga, tomate, cebolla, queso";
            recipeC.PostedBy = 3;
            recipeC.IsActive = true;
            recipeC.IsPublic = true;
            recipeC.InsertDate = DateTime.Now.AddDays(1);

            // Act
            var isValidA = RecipeItemService.ValidateRecipe(recipeA);
            var isValidB = RecipeItemService.ValidateRecipe(recipeB);
            var isValidC = RecipeItemService.ValidateRecipe(recipeC);

            // Assert
            Assert.AreEqual(false, isValidA, "El testede modelo de UserA ha fallado");
            Assert.AreEqual(false, isValidB, "Custom error message");
            Assert.AreEqual(false, isValidC, "Custom error message");
        }


    }
}