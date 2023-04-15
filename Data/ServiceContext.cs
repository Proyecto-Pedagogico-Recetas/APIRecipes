using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Entities.Relations;
using System.Reflection.Emit;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<AlergenItem> Alergens { get; set; }
        public DbSet<RecipeItem> Recipes { get; set; }
        public DbSet<IngredientItem> Ingredients { get; set; }
        public DbSet<CategoryItem> Categories { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<UserRolItem> RolType { get; set; }
        //public DbSet<AuthorizationItem> Authorizations { get; set; }

        public DbSet<Recipe_Alergen> Recipe_Alergens { get; set; }
        public DbSet<Recipe_Ingredient> Recipe_Ingredients { get; set; }
        //public DbSet<Rol_Authorization> Rol_Authorization{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecipeItem>(entity => {
                entity.ToTable("Recipes");
                builder.Entity<RecipeItem>().HasKey(p => p.Id);
                
                entity.HasOne<CategoryItem>().WithMany().HasForeignKey(r => r.Category);
             
            });

            builder.Entity<AlergenItem>(entity => {
                entity.ToTable("Alergens");
                builder.Entity<AlergenItem>().HasKey(p => p.Id);
            });

            builder.Entity<IngredientItem>(entity => {
                entity.ToTable("Ingredients");
                builder.Entity<IngredientItem>().HasKey(p => p.Id);
                //builder.Entity<IngredientItem>().HasIndex(i => i.Ingredient).IsUnique();
            });

            builder.Entity<CategoryItem>(entity => {
                entity.ToTable("Categories");
                builder.Entity<CategoryItem>().HasKey(p => p.Id);
            });

            builder.Entity<UserItem>(entity => {
                entity.ToTable("Users");
                builder.Entity<UserItem>().HasKey(p => p.Id);
                entity.HasOne<UserRolItem>().WithMany().HasForeignKey(u => u.IdRol);
            });

            builder.Entity<UserRolItem>(entity => {
                entity.ToTable("RolType");
                builder.Entity<UserRolItem>().HasKey(p => p.Id);
            });

            //builder.Entity<AuthorizationItem>(entity => {
            //    entity.ToTable("Authotizations");
            //    builder.Entity<AuthorizationItem>().HasKey(p => p.Id);
            //});

            builder.Entity<Recipe_Alergen>(entity => {
                entity.ToTable("Recipe_Alergens");
                builder.Entity<Recipe_Alergen>().HasKey(p => p.Id);
                //builder.Entity<Recipe_Alergen>().HasNoKey();
                // estas las quito para probar el virtual de Gepeto
                //entity.HasOne<RecipeItem>().WithMany().HasForeignKey(r => r.RecipeId);
                //entity.HasOne<AlergenItem>().WithMany().HasForeignKey(r => r.AlergenId);
                builder.Entity<Recipe_Alergen>().HasOne(ra => ra.Recipes)
                              .WithMany(r => r.Alergens)
                              .HasForeignKey(ra => ra.RecipeId);
                builder.Entity<Recipe_Alergen>().HasOne(ra => ra.Alergens)
                             .WithMany(a => a.Alergens)
                             .HasForeignKey(ra => ra.AlergenId);



            });

            builder.Entity<Recipe_Ingredient>(entity => {
                entity.ToTable("Recipe_Ingredients");
                builder.Entity<Recipe_Ingredient>().HasKey(p => p.Id);
                entity.HasOne<RecipeItem>().WithMany().HasForeignKey(r => r.RecipeId);
                entity.HasOne<IngredientItem>().WithMany().HasForeignKey(r => r.IngredientId);
            });

            //builder.Entity<Rol_Authorization>(entity => {
            //    entity.ToTable("Rol_Authorization");
            //    builder.Entity<Rol_Authorization>().HasKey(p => p.Id);
            //    entity.HasOne<UserRolItem>().WithMany().HasForeignKey(r => r.IdRol);
            //    entity.HasOne<AuthorizationItem>().WithMany().HasForeignKey(r => r.IdAuthorization);
            //});
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


        }
    }
 
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }
}
