using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_AdminPanel.Migrations.MySQLDb
{
    public partial class BacktoDepID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Trip");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Trip",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Trip",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
