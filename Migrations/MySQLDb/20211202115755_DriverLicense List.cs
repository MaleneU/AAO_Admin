using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_AdminPanel.Migrations.MySQLDb
{
    public partial class DriverLicenseList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicense_Driver_DriverID",
                table: "DriverLicense");

            migrationBuilder.DropColumn(
                name: "DriveID",
                table: "DriverLicense");

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "DriverLicense",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicense_Driver_DriverID",
                table: "DriverLicense",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "DriverID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicense_Driver_DriverID",
                table: "DriverLicense");

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "DriverLicense",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DriveID",
                table: "DriverLicense",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicense_Driver_DriverID",
                table: "DriverLicense",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "DriverID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
