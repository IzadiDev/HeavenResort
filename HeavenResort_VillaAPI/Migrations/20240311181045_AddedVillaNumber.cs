using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeavenResort_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1532), new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1536), new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1536) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1539), new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1539) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1541), new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1544), new DateTime(2024, 3, 9, 20, 22, 5, 954, DateTimeKind.Local).AddTicks(1545) });
        }
    }
}
