using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1EF.Migrations
{
    public partial class addedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Erik Johansson" },
                    { 2, "Sofie Silvstedt" },
                    { 3, "Mikael Forsgren" }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "LeaveTypeName" },
                values: new object[,]
                {
                    { 1, "Sickness" },
                    { 2, "Parental" },
                    { 3, "Vacation" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "LeaveId", "CreatedDate", "EmployeeId", "EndDate", "LeaveTypeId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2018, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2018, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2018, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
