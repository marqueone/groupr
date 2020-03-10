using Microsoft.EntityFrameworkCore.Migrations;

namespace net.marqueone.groupr.webapi.Migrations
{
    public partial class GroupNormalizedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "groups",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "groups");
        }
    }
}
