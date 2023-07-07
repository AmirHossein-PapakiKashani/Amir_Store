using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amir_Store.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 18, 9, 444, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 18, 9, 444, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 18, 9, 444, DateTimeKind.Local).AddTicks(4929));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 24, 19, 16, 43, 431, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 24, 19, 16, 43, 431, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 24, 19, 16, 43, 431, DateTimeKind.Local).AddTicks(2880));
        }
    }
}
