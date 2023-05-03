using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixingrecipepost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemRecipeItem_Categories_RecipeCategoryId",
                table: "CategoryItemRecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemRecipeItem_Recipes_RecipeId",
                table: "CategoryItemRecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_PostedBy",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Recipes_RecipeItemId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserItemId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecipeItemId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserItemId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PostedBy",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserItemId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "CategoryItemRecipeItem",
                newName: "RecipesId");

            migrationBuilder.RenameColumn(
                name: "RecipeCategoryId",
                table: "CategoryItemRecipeItem",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItemRecipeItem_RecipeId",
                table: "CategoryItemRecipeItem",
                newName: "IX_CategoryItemRecipeItem_RecipesId");

            migrationBuilder.AlterColumn<int>(
                name: "PosterId",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostedBy",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecipeItemUserItem",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeItemUserItem", x => new { x.RecipesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RecipeItemUserItem_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeItemUserItem_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PosterId",
                table: "Recipes",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItemUserItem_UsersId",
                table: "RecipeItemUserItem",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemRecipeItem_Categories_CategoriesId",
                table: "CategoryItemRecipeItem",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemRecipeItem_Recipes_RecipesId",
                table: "CategoryItemRecipeItem",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_PosterId",
                table: "Recipes",
                column: "PosterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemRecipeItem_Categories_CategoriesId",
                table: "CategoryItemRecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemRecipeItem_Recipes_RecipesId",
                table: "CategoryItemRecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_PosterId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeItemUserItem");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PosterId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipesId",
                table: "CategoryItemRecipeItem",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategoryItemRecipeItem",
                newName: "RecipeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItemRecipeItem_RecipesId",
                table: "CategoryItemRecipeItem",
                newName: "IX_CategoryItemRecipeItem_RecipeId");

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

            migrationBuilder.AlterColumn<string>(
                name: "PosterId",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PostedBy",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecipeItemId",
                table: "Users",
                column: "RecipeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserItemId",
                table: "Users",
                column: "UserItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PostedBy",
                table: "Recipes",
                column: "PostedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemRecipeItem_Categories_RecipeCategoryId",
                table: "CategoryItemRecipeItem",
                column: "RecipeCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemRecipeItem_Recipes_RecipeId",
                table: "CategoryItemRecipeItem",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_PostedBy",
                table: "Recipes",
                column: "PostedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
