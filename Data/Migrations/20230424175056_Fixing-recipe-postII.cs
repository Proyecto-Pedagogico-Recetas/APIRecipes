using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingrecipepostII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_PosterId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PosterId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "PostedBy",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PosterName",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PostedBy",
                table: "Recipes",
                column: "PostedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_PostedBy",
                table: "Recipes",
                column: "PostedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_PostedBy",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PostedBy",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "PosterName",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "PostedBy",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PosterId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PosterId",
                table: "Recipes",
                column: "PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_PosterId",
                table: "Recipes",
                column: "PosterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
