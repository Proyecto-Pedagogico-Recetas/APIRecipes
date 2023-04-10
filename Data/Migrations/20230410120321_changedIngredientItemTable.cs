using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class changedIngredientItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredients_Recipes_RecipeItemId",
                table: "Recipe_Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_Ingredients_RecipeItemId",
                table: "Recipe_Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "Recipe_Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeItemId",
                table: "Ingredients",
                column: "RecipeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeItemId",
                table: "Ingredients",
                column: "RecipeItemId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeItemId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeItemId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "Recipe_Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Ingredients_RecipeItemId",
                table: "Recipe_Ingredients",
                column: "RecipeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredients_Recipes_RecipeItemId",
                table: "Recipe_Ingredients",
                column: "RecipeItemId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
