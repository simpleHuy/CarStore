using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class addMoreShowroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowroom",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "showrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    Hotline = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsReputation = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Facebook = table.Column<string>(type: "text", nullable: true),
                    Home = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_showrooms_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    ShowroomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_showrooms_ShowroomId",
                        column: x => x.ShowroomId,
                        principalTable: "showrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "OwnerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "OwnerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                column: "OwnerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                column: "OwnerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                column: "OwnerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                column: "OwnerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                column: "OwnerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 8,
                column: "OwnerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 9,
                column: "OwnerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 10,
                column: "OwnerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsShowroom",
                value: false);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccountType", "Email", "IsShowroom", "Name", "PasswordHash", "Salt", "Telephone", "Username", "firstName", "lastName" },
                values: new object[,]
                {
                    { 2, null, "anycar@gmail.com", true, null, null, null, null, "anycar", null, null },
                    { 3, null, "StarupShow@gmail.com", true, null, null, null, null, "StarupShow", null, null }
                });

            migrationBuilder.InsertData(
                table: "showrooms",
                columns: new[] { "Id", "Email", "Facebook", "Home", "Hotline", "Img", "IsReputation", "Name", "UserId" },
                values: new object[] { 1, "info@anycar.vn", "https://www.facebook.com/anycar.vn/", "https://anycar.vn/", "18006216", "../Assets/ShowRoomAvatar.jpg", true, "Anycar.vn", 2 });

            migrationBuilder.InsertData(
                table: "showrooms",
                columns: new[] { "Id", "Email", "Facebook", "Home", "Hotline", "Img", "Name", "UserId" },
                values: new object[] { 2, "info@StarupShow.vn", null, null, "18006215", "../Assets/ShowRoom2.png", "Star-up Show", 3 });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "Id", "City", "ShowroomId", "Street" },
                values: new object[,]
                {
                    { 1, "Hà Nội", 1, "Số 3-5 Nguyễn Văn Linh, P. Gia Thụy, Q. Long Biên, Hà Nội" },
                    { 2, "Hồ Chí Minh", 1, "Số 250 Lương Định Của, P. An Phú, TP. Thủ Đức, TP Hồ Chí Minh" },
                    { 3, "Hồ Chí Minh", 2, "Vành đài ktx B, TP. Thủ Đức, TP Hồ Chí Minh" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_ShowroomId",
                table: "addresses",
                column: "ShowroomId");

            migrationBuilder.CreateIndex(
                name: "IX_showrooms_UserId",
                table: "showrooms",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_users_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_users_OwnerId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "showrooms");

            migrationBuilder.DropIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "IsShowroom",
                table: "users");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cars");
        }
    }
}
