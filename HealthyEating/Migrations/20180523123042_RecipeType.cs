using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyEating.Migrations
{
    public partial class RecipeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //  migrationBuilder.DropColumn(
            //      name: "UserID",
            //      table: "Recipe");

            // migrationBuilder.DropColumn(
            //     name: "UserID",
            //     table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "RecipeTypeID",
                table: "MenuChoice",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MealPlan",
                table: "Menu",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuChoice_RecipeTypeID",
                table: "MenuChoice",
                column: "RecipeTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuChoice_RecipeType_RecipeTypeID",
                table: "MenuChoice",
                column: "RecipeTypeID",
                principalTable: "RecipeType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuChoice_RecipeType_RecipeTypeID",
                table: "MenuChoice");

            migrationBuilder.DropTable(
                name: "RecipeType");

            migrationBuilder.DropIndex(
                name: "IX_MenuChoice_RecipeTypeID",
                table: "MenuChoice");

            migrationBuilder.DropColumn(
                name: "RecipeTypeID",
                table: "MenuChoice");

            //   migrationBuilder.AddColumn<string>(
            //       name: "UserID",
            //       table: "Recipe",
            //       nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MealPlan",
                table: "Menu",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "UserID",
            //     table: "Menu",
            //     nullable: true);
        }
    }
}
