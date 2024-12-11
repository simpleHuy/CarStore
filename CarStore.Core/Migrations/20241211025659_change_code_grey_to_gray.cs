using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class change_code_grey_to_gray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "Gray");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "Grey");
        }
    }
}
