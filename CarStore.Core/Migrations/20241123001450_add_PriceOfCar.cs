using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class add_PriceOfCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TypeOfCars_TypeOfCarId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Cars_CarId",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_variantsOfCars_Cars_CarId",
                table: "variantsOfCars");

            migrationBuilder.DropForeignKey(
                name: "FK_variantsOfCars_variants_VariantId",
                table: "variantsOfCars");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Details",
                table: "Details");

            migrationBuilder.RenameTable(
                name: "Details",
                newName: "CarDetails");

            migrationBuilder.AddColumn<int>(
                name: "PriceOfCarId",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDetails",
                table: "CarDetails",
                column: "CarId");

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
                column: "PriceOfCarId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "PriceOfCarId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                column: "PriceOfCarId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                column: "PriceOfCarId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                column: "PriceOfCarId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                column: "PriceOfCarId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                column: "PriceOfCarId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 8,
                column: "PriceOfCarId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 9,
                column: "PriceOfCarId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 10,
                column: "PriceOfCarId",
                value: 2);

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
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                table: "Cars",
                column: "EngineTypeId",
                principalTable: "EngineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TypeOfCars_TypeOfCarId",
                table: "Cars",
                column: "TypeOfCarId",
                principalTable: "TypeOfCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_priceOfCars_PriceOfCarId",
                table: "Cars",
                column: "PriceOfCarId",
                principalTable: "priceOfCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_variantsOfCars_Cars_CarId",
                table: "variantsOfCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_variantsOfCars_variants_VariantId",
                table: "variantsOfCars",
                column: "VariantId",
                principalTable: "variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TypeOfCars_TypeOfCarId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_priceOfCars_PriceOfCarId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_variantsOfCars_Cars_CarId",
                table: "variantsOfCars");

            migrationBuilder.DropForeignKey(
                name: "FK_variantsOfCars_variants_VariantId",
                table: "variantsOfCars");

            migrationBuilder.DropTable(
                name: "priceOfCars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PriceOfCarId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDetails",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "PriceOfCarId",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "CarDetails",
                newName: "Details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Details",
                table: "Details",
                column: "CarId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_CarId",
                table: "Schedule",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                table: "Cars",
                column: "EngineTypeId",
                principalTable: "EngineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TypeOfCars_TypeOfCarId",
                table: "Cars",
                column: "TypeOfCarId",
                principalTable: "TypeOfCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Cars_CarId",
                table: "Details",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_variantsOfCars_Cars_CarId",
                table: "variantsOfCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_variantsOfCars_variants_VariantId",
                table: "variantsOfCars",
                column: "VariantId",
                principalTable: "variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
