using Microsoft.EntityFrameworkCore.Migrations;

namespace net.marqueone.groupr.webapi.Migrations
{
    public partial class GroupDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "groups",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "groups");
        }
    }
}
