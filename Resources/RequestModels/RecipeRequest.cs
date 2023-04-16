using Data;
using Entities.Entities;
using Entities.Relations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resources.RequestModels
{
    public class RecipeRequest
    {
        //JsonSerializerOptions options = new JsonSerializerOptions
        //{
        //    IncludeFields = true
        //};

        // Luego puedes utilizar el objeto 'options' en la deserialización
        //RecipeRequest recipeRequest = JsonSerializer.Deserialize<RecipeRequest>(jsonString, options);

        //private readonly ServiceContext _serviceContext;

        // Constructor para inyectar el contexto de servicio
        //public RecipeRequest(ServiceContext serviceContext)
        //{
        //    _serviceContext = serviceContext;
        //}
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int Category { get; set; }
        public string Author { get; set; }
        public string? Observations { get; set; }
        public string? Materials { get; set; }
        public int PostedBy { get; set; }
        public List<IngredientRequest> Ingredients { get; set; }
        public List<AlergenRequest> Alergens { get; set; }

        public RecipeItem ToRecipeItem()
        {
            var recipeItem = new RecipeItem();

            recipeItem.IsPublic = true;
           recipeItem.IsActive = true;
            recipeItem.InsertDate = DateTime.Now;
            return recipeItem;
        }


        //public async Task<List<AlergenRequest>> ToListAlergensAsync()
        //{
        //    var alergensList = await _serviceContext.Set<AlergenItem>()
        //        .Where(u => u.IsActive == true)
        //        .Select(u => new AlergenRequest
        //        {
        //            Name = u.Name,
        //        //    IsChecked = false  Puedes establecer el valor predeterminado de IsChecked según tus necesidades
        //        })
        //        .ToListAsync();

        //    return alergensList;
        //}

    }

}

        //public List<AlergenItem> ToListAlergens()
        //{
        //    var alergensList = new List<AlergenItem>();
        //    _serviceContext.Set<AlergenItem>().ToList()
        //    .Where(u => u.IsActive == false);
        //    return alergensList;
        //}
        //public async Task<List<AlergenRequest>> GetAlergensFromDatabase()
        //{
        //    var alergensList = await _serviceContext.Set<AlergenItem>()
        //        .Where(u => u.IsActive == false)
        //        .Select(a => new AlergenRequest { Name = a.Name, IsChecked = false })
        //        .ToListAsync();

        //    return alergensList;
        //}