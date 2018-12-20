using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiService.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesData",
                columns: table => new
                {
                    EmployeeDataId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesData", x => x.EmployeeDataId);
                    table.ForeignKey(
                        name: "FK_EmployeesData_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 1, "Mangesh", "G" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 2, "Ramnath", "Bodke" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 3, "Suraj", "G" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 4, "Jaffar", "K" });

            migrationBuilder.InsertData(
                table: "EmployeesData",
                columns: new[] { "EmployeeDataId", "Email", "EmployeeId", "Gender", "Phone" },
                values: new object[] { 1, "Mangesh.g@outlook.com", 1, "1", "123" });

            migrationBuilder.InsertData(
                table: "EmployeesData",
                columns: new[] { "EmployeeDataId", "Email", "EmployeeId", "Gender", "Phone" },
                values: new object[] { 2, "Ramnagh.g@outlook.com", 2, "1", "223" });

            migrationBuilder.InsertData(
                table: "EmployeesData",
                columns: new[] { "EmployeeDataId", "Email", "EmployeeId", "Gender", "Phone" },
                values: new object[] { 3, "suraj.g@gmail.com", 3, "1", "323" });

            migrationBuilder.InsertData(
                table: "EmployeesData",
                columns: new[] { "EmployeeDataId", "Email", "EmployeeId", "Gender", "Phone" },
                values: new object[] { 4, "Jaffar.g@outlook.com", 4, "1", "423" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesData_EmployeeId",
                table: "EmployeesData",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesData");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
