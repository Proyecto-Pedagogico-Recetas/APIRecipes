using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingcategorynposterNameinrecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserItemId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PosterId",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CategoryItemRecipeItem",
                columns: table => new
                {
                    RecipeCategoryId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemRecipeItem", x => new { x.RecipeCategoryId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_CategoryItemRecipeItem_Categories_RecipeCategoryId",
                        column: x => x.RecipeCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryItemRecipeItem_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecipeItemId",
                table: "Users",
                column: "RecipeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserItemId",
                table: "Users",
                column: "UserItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemRecipeItem_RecipeId",
                table: "CategoryItemRecipeItem",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Recipes_RecipeItemId",
                table: "Users",
                column: "RecipeItemId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserItemId",
                table: "Users",
                column: "UserItemId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Recipes_RecipeItemId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserItemId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CategoryItemRecipeItem");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecipeItemId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserItemId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserItemId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
