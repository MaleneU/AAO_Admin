using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace AAO_AdminPanel.Migrations.MySQLDb
{
    public partial class Relations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_City_CityID",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip");

            migrationBuilder.DropTable(
                name: "TripHasDriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverLicense",
                table: "DriverLicense");

            migrationBuilder.DropIndex(
                name: "IX_Country_CityID",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DescriptionOfTrip",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "StartCountryID",
                table: "Traffic");

            migrationBuilder.DropColumn(
                name: "StopCountryID",
                table: "Traffic");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Traffic");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Country");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Type",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrafficID",
                table: "Trip",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Trip",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Trip",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartLocationID",
                table: "Trip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Urgent",
                table: "Trip",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Trip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartCountryCountryID",
                table: "Traffic",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StopCountryCountryID",
                table: "Traffic",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrafficTypeTypeID",
                table: "Traffic",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "StartLocation",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripID",
                table: "Request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "Request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LicenseName",
                table: "License",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "DriverLicense",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "DriverLicense",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LicenseID",
                table: "DriverLicense",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DriverLicenseID",
                table: "DriverLicense",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "StartLocationID",
                table: "Driver",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TrafficTypeTypeID",
                table: "Driver",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "RequestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverLicense",
                table: "DriverLicense",
                column: "DriverLicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_StartLocationID",
                table: "Trip",
                column: "StartLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TrafficID",
                table: "Trip",
                column: "TrafficID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_UserID",
                table: "Trip",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Traffic_StartCountryCountryID",
                table: "Traffic",
                column: "StartCountryCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Traffic_StopCountryCountryID",
                table: "Traffic",
                column: "StopCountryCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Traffic_TrafficTypeTypeID",
                table: "Traffic",
                column: "TrafficTypeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_DriverID",
                table: "Request",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusID",
                table: "Request",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TripID",
                table: "Request",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicense_DriverID",
                table: "DriverLicense",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicense_LicenseID",
                table: "DriverLicense",
                column: "LicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_StartLocationID",
                table: "Driver",
                column: "StartLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TrafficTypeTypeID",
                table: "Driver",
                column: "TrafficTypeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_UserID",
                table: "Driver",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityID",
                table: "Address",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityID",
                table: "Address",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_StartLocation_StartLocationID",
                table: "Driver",
                column: "StartLocationID",
                principalTable: "StartLocation",
                principalColumn: "StartLocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Type_TrafficTypeTypeID",
                table: "Driver",
                column: "TrafficTypeTypeID",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_User_UserID",
                table: "Driver",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicense_Driver_DriverID",
                table: "DriverLicense",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "DriverID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicense_License_LicenseID",
                table: "DriverLicense",
                column: "LicenseID",
                principalTable: "License",
                principalColumn: "LicenseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "DriverID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Status_StatusID",
                table: "Request",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Trip_TripID",
                table: "Request",
                column: "TripID",
                principalTable: "Trip",
                principalColumn: "TripID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Traffic_Type_TrafficTypeTypeID",
                table: "Traffic",
                column: "TrafficTypeTypeID",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_StartLocation_StartLocationID",
                table: "Trip",
                column: "StartLocationID",
                principalTable: "StartLocation",
                principalColumn: "StartLocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Traffic_TrafficID",
                table: "Trip",
                column: "TrafficID",
                principalTable: "Traffic",
                principalColumn: "TrafficID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_User_UserID",
                table: "Trip",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_StartLocation_StartLocationID",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Type_TrafficTypeTypeID",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_User_UserID",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicense_Driver_DriverID",
                table: "DriverLicense");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicense_License_LicenseID",
                table: "DriverLicense");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Status_StatusID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Trip_TripID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Traffic_Country_StartCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropForeignKey(
                name: "FK_Traffic_Country_StopCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropForeignKey(
                name: "FK_Traffic_Type_TrafficTypeTypeID",
                table: "Traffic");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_StartLocation_StartLocationID",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Traffic_TrafficID",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_User_UserID",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_StartLocationID",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_TrafficID",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_UserID",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Traffic_StartCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropIndex(
                name: "IX_Traffic_StopCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropIndex(
                name: "IX_Traffic_TrafficTypeTypeID",
                table: "Traffic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_DriverID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_StatusID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_TripID",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverLicense",
                table: "DriverLicense");

            migrationBuilder.DropIndex(
                name: "IX_DriverLicense_DriverID",
                table: "DriverLicense");

            migrationBuilder.DropIndex(
                name: "IX_DriverLicense_LicenseID",
                table: "DriverLicense");

            migrationBuilder.DropIndex(
                name: "IX_Driver_StartLocationID",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Driver_TrafficTypeTypeID",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Driver_UserID",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryID",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Address_CityID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "StartLocationID",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Urgent",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "StartCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropColumn(
                name: "StopCountryCountryID",
                table: "Traffic");

            migrationBuilder.DropColumn(
                name: "TrafficTypeTypeID",
                table: "Traffic");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "DriverLicenseID",
                table: "DriverLicense");

            migrationBuilder.DropColumn(
                name: "TrafficTypeTypeID",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "City");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Type",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrafficID",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionOfTrip",
                table: "Trip",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartCountryID",
                table: "Traffic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StopCountryID",
                table: "Traffic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Traffic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "StartLocation",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "LicenseName",
                table: "License",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LicenseID",
                table: "DriverLicense",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "DriverLicense",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "DriverLicense",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StartLocationID",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "DriverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverLicense",
                table: "DriverLicense",
                column: "LicenseID");

            migrationBuilder.CreateTable(
                name: "TripHasDriver",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TripID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripHasDriver", x => x.DriverID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CityID",
                table: "Country",
                column: "CityID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Country_City_CityID",
                table: "Country",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Department_DepartmentID",
                table: "Trip",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
