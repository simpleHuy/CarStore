using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class update_PriceOfCar_in_Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                column: "PriceOfCarId",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                column: "PriceOfCarId",
                value: 2);
        }
    }
}
