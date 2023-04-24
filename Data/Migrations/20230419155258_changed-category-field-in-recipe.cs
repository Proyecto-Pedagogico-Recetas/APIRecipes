using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class changedcategoryfieldinrecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_Category",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Recipes",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_Category",
                table: "Recipes",
                newName: "IX_Recipes_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Recipes",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                newName: "IX_Recipes_Category");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_Category",
                table: "Recipes",
                column: "Category",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
