using Microsoft.EntityFrameworkCore.Migrations;

namespace EFStudy.Migrations
{
    public partial class EFStudy10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Producs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Producs");
        }
    }
}
