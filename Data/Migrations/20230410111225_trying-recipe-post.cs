using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class tryingrecipepost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Recipe_Ingredients",
                newName: "Amount");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Recipe_Ingredients",
                newName: "Quantity");
        }
    }
}
