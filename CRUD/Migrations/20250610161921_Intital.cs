using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class Intital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employes",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "Gender", "HireDate", "IsActive", "JobTitle", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John", 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Software Engineer", "Doe", "1234567890", 75000m },
                    { 2, 2, "jane.smith@example.com", "Jane", 1, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "QA Analyst", "Smith", "2345678901", 65000m },
                    { 3, 3, "robert.brown@example.com", "Robert", 0, new DateTime(2018, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Project Manager", "Brown", "3456789012", 90000m },
                    { 4, 4, "emily.clark@example.com", "Emily", 1, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "UX Designer", "Clark", "4567890123", 70000m },
                    { 5, 5, "daniel.lee@example.com", "Daniel", 0, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "DevOps Engineer", "Lee", "5678901234", 80000m },
                    { 6, 6, "olivia.walker@example.com", "Olivia", 1, new DateTime(2017, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "HR Manager", "Walker", "6789012345", 85000m },
                    { 7, 7, "david.king@example.com", "David", 0, new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Network Engineer", "King", "7890123456", 72000m },
                    { 8, 8, "sophia.allen@example.com", "Sophia", 1, new DateTime(2016, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "System Analyst", "Allen", "8901234567", 69000m },
                    { 9, 9, "james.scott@example.com", "James", 0, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "IT Support", "Scott", "9012345678", 55000m },
                    { 10, 10, "grace.green@example.com", "Grace", 1, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Security Analyst", "Green", "0123456789", 78000m },
                    { 11, 1, "aaron.young@example.com", "Aaron", 0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Frontend Developer", "Young", "1231231234", 73000m },
                    { 12, 2, "zoe.hill@example.com", "Zoe", 1, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Backend Developer", "Hill", "2342342345", 77000m },
                    { 13, 3, "ethan.wright@example.com", "Ethan", 0, new DateTime(2015, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Database Admin", "Wright", "3453453456", 88000m },
                    { 14, 4, "lily.lopez@example.com", "Lily", 1, new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mobile Developer", "Lopez", "4564564567", 71000m },
                    { 15, 5, "henry.adams@example.com", "Henry", 0, new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Business Analyst", "Adams", "5675675678", 76000m },
                    { 16, 6, "ella.baker@example.com", "Ella", 1, new DateTime(2017, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tech Lead", "Baker", "6786786789", 98000m },
                    { 17, 7, "logan.nelson@example.com", "Logan", 0, new DateTime(2014, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Architect", "Nelson", "7897897890", 102000m },
                    { 18, 8, "chloe.carter@example.com", "Chloe", 1, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Consultant", "Carter", "8908908901", 85000m },
                    { 19, 9, "lucas.mitchell@example.com", "Lucas", 0, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Trainer", "Mitchell", "9019019012", 60000m },
                    { 20, 10, "ava.perez@example.com", "Ava", 1, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Content Strategist", "Perez", "0120120123", 67000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employes");
        }
    }
}
