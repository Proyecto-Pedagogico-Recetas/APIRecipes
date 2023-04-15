using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RecipegetvirtualII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Alergens_Alergens_AlergenId",
                table: "Recipe_Alergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Alergens_Recipes_RecipeId",
                table: "Recipe_Alergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredients_Ingredients_IngredientId",
                table: "Recipe_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredients_Recipes_RecipeId",
                table: "Recipe_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_Category",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Recipe_Alergens_AlergensId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RolType_IdRol",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AlergensId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "AlergensId",
                table: "Recipes");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Alergens_Alergens_AlergenId",
                table: "Recipe_Alergens",
                column: "AlergenId",
                principalTable: "Alergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Alergens_Recipes_RecipeId",
                table: "Recipe_Alergens",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredients_Ingredients_IngredientId",
                table: "Recipe_Ingredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredients_Recipes_RecipeId",
                table: "Recipe_Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_Category",
                table: "Recipes",
                column: "Category",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RolType_IdRol",
                table: "Users",
                column: "IdRol",
                principalTable: "RolType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Alergens_Alergens_AlergenId",
                table: "Recipe_Alergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Alergens_Recipes_RecipeId",
                table: "Recipe_Alergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredients_Ingredients_IngredientId",
                table: "Recipe_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredients_Recipes_RecipeId",
                table: "Recipe_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_Category",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RolType_IdRol",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AlergensId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AlergensId",
                table: "Recipes",
                column: "AlergensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Alergens_Alergens_AlergenId",
                table: "Recipe_Alergens",
                column: "AlergenId",
                principalTable: "Alergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Alergens_Recipes_RecipeId",
                table: "Recipe_Alergens",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredients_Ingredients_IngredientId",
                table: "Recipe_Ingredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredients_Recipes_RecipeId",
                table: "Recipe_Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_Category",
                table: "Recipes",
                column: "Category",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Recipe_Alergens_AlergensId",
                table: "Recipes",
                column: "AlergensId",
                principalTable: "Recipe_Alergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RolType_IdRol",
                table: "Users",
                column: "IdRol",
                principalTable: "RolType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
