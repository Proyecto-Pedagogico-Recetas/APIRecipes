using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Recipegetvirtual : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Recipe_Alergens",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe_Alergens",
                table: "Recipe_Alergens",
                column: "Id");

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
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe_Alergens",
                table: "Recipe_Alergens");

            migrationBuilder.DropColumn(
                name: "AlergensId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Recipe_Alergens");
        }
    }
}
