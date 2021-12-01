using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_AdminPanel.Migrations.MySQLDb
{
    public partial class DbsetCountryadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traffic_Country_StartCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropForeignKey(
                name: "FK_Traffic_Country_StopCountryCountryID",
                table: "Traffic");

            migrationBuilder.AlterColumn<int>(
                name: "StopCountryCountryID",
                table: "Traffic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StartCountryCountryID",
                table: "Traffic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Traffic_Country_StartCountryCountryID",
                table: "Traffic",
                column: "StartCountryCountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traffic_Country_StopCountryCountryID",
                table: "Traffic",
                column: "StopCountryCountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traffic_Country_StartCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropForeignKey(
                name: "FK_Traffic_Country_StopCountryCountryID",
                table: "Traffic");

            migrationBuilder.AlterColumn<int>(
                name: "StopCountryCountryID",
                table: "Traffic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StartCountryCountryID",
                table: "Traffic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Traffic_Country_StartCountryCountryID",
                table: "Traffic",
                column: "StartCountryCountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Traffic_Country_StopCountryCountryID",
                table: "Traffic",
                column: "StopCountryCountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
