using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Recipegetvirtualfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Recipes_Recipe_Alergens_AlergensId",
                table: "Recipes",
                column: "AlergensId",
                principalTable: "Recipe_Alergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Recipe_Alergens_AlergensId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AlergensId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "AlergensId",
                table: "Recipes");
        }
    }
}
