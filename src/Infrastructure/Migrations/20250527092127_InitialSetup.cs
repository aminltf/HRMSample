using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IssuePlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    MarriageDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    HousingStatus = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCode",
                table: "Employees",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FirstName",
                table: "Employees",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MobileNumber",
                table: "Employees",
                column: "MobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalCode",
                table: "Employees",
                column: "NationalCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
