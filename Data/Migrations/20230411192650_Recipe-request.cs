using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Reciperequest : Migration
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
                name: "Name",
                table: "Recipe_Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "Recipe_Ingredients");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Recipes",
                newName: "Instructions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "Ingredient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "Recipes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Ingredient",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipe_Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
