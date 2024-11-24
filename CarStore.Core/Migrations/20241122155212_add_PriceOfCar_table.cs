using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class add_PriceOfCar_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "CarId",
                keyValue: 10);

            migrationBuilder.AddColumn<int>(
                name: "CarDetailId",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceOfCarId",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "priceOfCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priceOfCars", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 8,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 9,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 10,
                columns: new[] { "CarDetailId", "PriceOfCarId" },
                values: new object[] { 0, 0 });

            migrationBuilder.InsertData(
                table: "priceOfCars",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dưới 500 triệu" },
                    { 2, "500 triệu - 1 tỷ" },
                    { 3, "1 tỷ - 2 tỷ" },
                    { 4, "2 tỷ - 3 tỷ" },
                    { 5, "Trên 3 tỷ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceOfCarId",
                table: "Cars",
                column: "PriceOfCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_priceOfCars_PriceOfCarId",
                table: "Cars",
                column: "PriceOfCarId",
                principalTable: "priceOfCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_priceOfCars_PriceOfCarId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "priceOfCars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PriceOfCarId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarDetailId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PriceOfCarId",
                table: "Cars");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MerchantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "CarId", "MaxDistance", "NumberSeat", "TimeGet100", "Year" },
                values: new object[,]
                {
                    { 1, 770, 5, 8.6999999999999993, 2022 },
                    { 2, 640, 5, 10.199999999999999, 2020 },
                    { 3, 850, 4, 5.2000000000000002, 2022 },
                    { 4, 710, 4, 3.3999999999999999, 2018 },
                    { 5, 800, 2, 4.2000000000000002, 2023 },
                    { 6, 750, 4, 3.3999999999999999, 2023 },
                    { 7, 780, 4, 4.5, 2023 },
                    { 8, 480, 4, 3.8999999999999999, 2023 },
                    { 9, 900, 5, 10.0, 2023 },
                    { 10, 470, 5, 8.5, 2023 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_CarId",
                table: "Schedule",
                column: "CarId");
        }
    }
}
