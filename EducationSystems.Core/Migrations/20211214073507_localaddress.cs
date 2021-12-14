using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationSystems.Core.Migrations
{
    public partial class localaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalAddress",
                table: "AspNetUsers");
        }
    }
}
