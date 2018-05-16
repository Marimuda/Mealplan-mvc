using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyEating.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Recipe",
                newName: "RecipeImage");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Recipe",
                newName: "RecipeCreationTime");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Recipe",
                newName: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeImage",
                table: "Recipe",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "RecipeCreationTime",
                table: "Recipe",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "Recipe",
                newName: "ID");
        }
    }
}
