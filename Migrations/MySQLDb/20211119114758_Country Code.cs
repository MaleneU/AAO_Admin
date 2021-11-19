using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_AdminPanel.Migrations.MySQLDb
{
    public partial class CountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Country",
                type: "varchar(2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Country");
        }
    }
}
