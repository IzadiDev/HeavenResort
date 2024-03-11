using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeavenResort_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyVillaAndVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2157), new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2157) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2160), new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2160) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2163), new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2163) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2165), new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2166) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2168), new DateTime(2024, 3, 11, 23, 15, 10, 102, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6262), new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6263) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6265), new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6266) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6268), new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6271), new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6272) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6274), new DateTime(2024, 3, 11, 21, 40, 44, 520, DateTimeKind.Local).AddTicks(6275) });
        }
    }
}
