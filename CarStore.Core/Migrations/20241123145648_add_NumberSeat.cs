using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class add_NumberSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberSeat",
                table: "CarDetails",
                newName: "NumberSeatId");

            migrationBuilder.CreateTable(
                name: "numberSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numberSeats", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 1,
                column: "NumberSeatId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 2,
                column: "NumberSeatId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 3,
                column: "NumberSeatId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 4,
                column: "NumberSeatId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 6,
                column: "NumberSeatId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 7,
                column: "NumberSeatId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 8,
                column: "NumberSeatId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 9,
                column: "NumberSeatId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 10,
                column: "NumberSeatId",
                value: 3);

            migrationBuilder.InsertData(
                table: "numberSeats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "2 chỗ" },
                    { 2, "4 chỗ" },
                    { 3, "5 chỗ" },
                    { 4, "7 chỗ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_NumberSeatId",
                table: "CarDetails",
                column: "NumberSeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_numberSeats_NumberSeatId",
                table: "CarDetails",
                column: "NumberSeatId",
                principalTable: "numberSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_numberSeats_NumberSeatId",
                table: "CarDetails");

            migrationBuilder.DropTable(
                name: "numberSeats");

            migrationBuilder.DropIndex(
                name: "IX_CarDetails_NumberSeatId",
                table: "CarDetails");

            migrationBuilder.RenameColumn(
                name: "NumberSeatId",
                table: "CarDetails",
                newName: "NumberSeat");

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 1,
                column: "NumberSeat",
                value: 5);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 2,
                column: "NumberSeat",
                value: 5);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 3,
                column: "NumberSeat",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 4,
                column: "NumberSeat",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 6,
                column: "NumberSeat",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 7,
                column: "NumberSeat",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 8,
                column: "NumberSeat",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 9,
                column: "NumberSeat",
                value: 5);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "CarId",
                keyValue: 10,
                column: "NumberSeat",
                value: 5);
        }
    }
}
