using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class fixAuctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "condition",
                table: "Auctions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "condition",
                table: "Auctions");
        }
    }
}
