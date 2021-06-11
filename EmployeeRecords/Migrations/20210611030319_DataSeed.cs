using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRecords.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 1L, "Juan", "Dela Cruz", "Tamad" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 2L, "Pedro", "De Lion", "Tamad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
