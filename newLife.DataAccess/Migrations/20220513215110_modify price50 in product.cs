using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newLife.Migrations
{
    public partial class modifyprice50inproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price5O",
                table: "Products",
                newName: "Price50");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price50",
                table: "Products",
                newName: "Price5O");
        }
    }
}
