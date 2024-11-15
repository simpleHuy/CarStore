using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarStore.Core.Migrations;

/// <inheritdoc />
public partial class init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Cars",
            columns: table => new
            {
                CarId = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                Name = table.Column<string>(type: "text", nullable: true),
                Manufacturer = table.Column<int>(type: "integer", nullable: true),
                EngineType = table.Column<int>(type: "integer", nullable: true),
                TypeOfCar = table.Column<int>(type: "integer", nullable: true),
                Price = table.Column<long>(type: "bigint", nullable: true),
                UsageStatus = table.Column<string>(type: "text", nullable: true),
                Description = table.Column<string>(type: "text", nullable: true),
                Images = table.Column<string>(type: "text", nullable: true),
                DefautlImageLocation = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cars", x => x.CarId);
            });

        migrationBuilder.CreateTable(
            name: "Variant",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                Name = table.Column<string>(type: "text", nullable: true),
                Code = table.Column<string>(type: "text", nullable: true),
                CarId = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Variant", x => x.Id);
                table.ForeignKey(
                    name: "FK_Variant_Cars_CarId",
                    column: x => x.CarId,
                    principalTable: "Cars",
                    principalColumn: "CarId");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Variant_CarId",
            table: "Variant",
            column: "CarId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Variant");

        migrationBuilder.DropTable(
            name: "Cars");
    }
}
