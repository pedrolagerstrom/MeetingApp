using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WPF.EmployeeManagement.DataAccess.Migrations
{
    public partial class Init : Migration
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
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "EmployeeId", "EndDate", "StartDate", "Title" },
                values: new object[] { 1, null, new DateTime(2021, 9, 11, 12, 24, 28, 877, DateTimeKind.Local).AddTicks(5779), new DateTime(2021, 9, 11, 10, 24, 28, 875, DateTimeKind.Local).AddTicks(7211), "Bostad" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MeetingId",
                table: "Employees",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_EmployeeId",
                table: "Meetings",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Employees_EmployeeId",
                table: "Meetings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Meetings_MeetingId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
