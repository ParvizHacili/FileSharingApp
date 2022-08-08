using Microsoft.EntityFrameworkCore.Migrations;

namespace FileSharingApp.Data.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
