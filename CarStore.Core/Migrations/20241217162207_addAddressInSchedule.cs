using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class addAddressInSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "schedules",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "showrooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img",
                value: "../Assets/ShowRoom2.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "schedules");

            migrationBuilder.UpdateData(
                table: "showrooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img",
                value: "../Assets/ShowRoomAvatar.jpg");
        }
    }
}
