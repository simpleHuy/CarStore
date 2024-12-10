using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class Auto_Generate_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_Cars_CarId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Username",
                table: "users",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_Cars_CarId",
                table: "schedules",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_Cars_CarId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Username",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_Cars_CarId",
                table: "schedules",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
