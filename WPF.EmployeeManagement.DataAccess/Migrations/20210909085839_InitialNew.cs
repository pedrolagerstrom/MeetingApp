using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WPF.EmployeeManagement.DataAccess.Migrations
{
    public partial class InitialNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Firstname", "Lastname", "MeetingId", "Phonenumber" },
                values: new object[,]
                {
                    { 1, 1, "johnny@gmail.com", "Rafael", "Milanes", null, "0701122334" },
                    { 2, 1, "Juan@gmail.com", "Johnny", "Cage", null, "0701122334" },
                    { 3, 2, "Anna@gmail.com", "Anna", "Lindgren", null, "0701122334" },
                    { 4, 3, "John@gmail.com", "Juanete", "Pérez", null, "0701122334" },
                    { 5, 3, "new@gmail.com", "New", "SuperNew", null, "0701122334" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MeetingId",
                table: "Employees",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
