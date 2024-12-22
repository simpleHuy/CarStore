using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Core.Migrations
{
    /// <inheritdoc />
    public partial class addMoreColorAndMoreManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Chevrolet" },
                    { 11, "Mercedes-Benz" },
                    { 12, "Hyundai" },
                    { 13, "Isuzu" },
                    { 14, "Suzuki" },
                    { 15, "Kia" },
                    { 16, "Mitsubishi" },
                    { 17, "Lexus" },
                    { 18, "Mazda" },
                    { 19, "BMW" },
                    { 20, "Peugeot" },
                    { 21, "Audi" },
                    { 22, "Land Rover" },
                    { 23, "Lamborghini" },
                    { 24, "Volvo" },
                    { 25, "Jaguar" },
                    { 26, "Bentley" }
                });

            migrationBuilder.InsertData(
                table: "variants",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 7, "AliceBlue" },
                    { 8, "AntiqueWhite" },
                    { 9, "Aqua" },
                    { 10, "Aquamarine" },
                    { 11, "Azure" },
                    { 12, "Beige" },
                    { 13, "Bisque" },
                    { 14, "BlanchedAlmond" },
                    { 15, "BlueViolet" },
                    { 16, "Brown" },
                    { 17, "BurlyWood" },
                    { 18, "CadetBlue" },
                    { 19, "Chartreuse" },
                    { 20, "Chocolate" },
                    { 21, "Coral" },
                    { 22, "CornflowerBlue" },
                    { 23, "Cornsilk" },
                    { 24, "Crimson" },
                    { 25, "Cyan" },
                    { 26, "DarkBlue" },
                    { 27, "DarkCyan" },
                    { 28, "DarkGoldenrod" },
                    { 29, "DarkGray" },
                    { 30, "DarkGreen" },
                    { 31, "DarkKhaki" },
                    { 32, "DarkMagenta" },
                    { 33, "DarkOliveGreen" },
                    { 34, "DarkOrange" },
                    { 35, "DarkOrchid" },
                    { 36, "DarkRed" },
                    { 37, "DarkSalmon" },
                    { 38, "DarkSeaGreen" },
                    { 39, "DarkSlateBlue" },
                    { 40, "DarkSlateGray" },
                    { 41, "DarkTurquoise" },
                    { 42, "DarkViolet" },
                    { 43, "DeepPink" },
                    { 44, "DeepSkyBlue" },
                    { 45, "DimGray" },
                    { 46, "DodgerBlue" },
                    { 47, "Firebrick" },
                    { 48, "FloralWhite" },
                    { 49, "ForestGreen" },
                    { 50, "Fuchsia" },
                    { 51, "Gainsboro" },
                    { 52, "GhostWhite" },
                    { 53, "Gold" },
                    { 54, "Goldenrod" },
                    { 55, "GreenYellow" },
                    { 56, "Honeydew" },
                    { 57, "HotPink" },
                    { 58, "IndianRed" },
                    { 59, "Indigo" },
                    { 60, "Ivory" },
                    { 61, "Khaki" },
                    { 62, "Lavender" },
                    { 63, "LavenderBlush" },
                    { 64, "LawnGreen" },
                    { 65, "LemonChiffon" },
                    { 66, "LightBlue" },
                    { 67, "LightCoral" },
                    { 68, "LightCyan" },
                    { 69, "LightGoldenrodYellow" },
                    { 70, "LightGray" },
                    { 71, "LightGreen" },
                    { 72, "LightPink" },
                    { 73, "LightSalmon" },
                    { 74, "LightSeaGreen" },
                    { 75, "LightSkyBlue" },
                    { 76, "LightSlateGray" },
                    { 77, "LightSteelBlue" },
                    { 78, "LightYellow" },
                    { 79, "Lime" },
                    { 80, "LimeGreen" },
                    { 81, "Linen" },
                    { 82, "Magenta" },
                    { 83, "Maroon" },
                    { 84, "MediumAquamarine" },
                    { 85, "MediumBlue" },
                    { 86, "MediumOrchid" },
                    { 87, "MediumPurple" },
                    { 88, "MediumSeaGreen" },
                    { 89, "MediumSlateBlue" },
                    { 90, "MediumSpringGreen" },
                    { 91, "MediumTurquoise" },
                    { 92, "MediumVioletRed" },
                    { 93, "MidnightBlue" },
                    { 94, "MintCream" },
                    { 95, "MistyRose" },
                    { 96, "Moccasin" },
                    { 97, "NavajoWhite" },
                    { 98, "Navy" },
                    { 99, "OldLace" },
                    { 100, "Olive" },
                    { 101, "OliveDrab" },
                    { 102, "Orange" },
                    { 103, "OrangeRed" },
                    { 104, "Orchid" },
                    { 105, "PaleGoldenrod" },
                    { 106, "PaleGreen" },
                    { 107, "PaleTurquoise" },
                    { 108, "PaleVioletRed" },
                    { 109, "PapayaWhip" },
                    { 110, "PeachPuff" },
                    { 111, "Peru" },
                    { 112, "Pink" },
                    { 113, "Plum" },
                    { 114, "PowderBlue" },
                    { 115, "Purple" },
                    { 116, "RosyBrown" },
                    { 117, "RoyalBlue" },
                    { 118, "SaddleBrown" },
                    { 119, "Salmon" },
                    { 120, "SandyBrown" },
                    { 121, "SeaGreen" },
                    { 122, "Seashell" },
                    { 123, "Sienna" },
                    { 124, "Silver" },
                    { 125, "SkyBlue" },
                    { 126, "SlateBlue" },
                    { 127, "SlateGray" },
                    { 128, "Snow" },
                    { 129, "SpringGreen" },
                    { 130, "SteelBlue" },
                    { 131, "Tan" },
                    { 132, "Teal" },
                    { 133, "Thistle" },
                    { 134, "Tomato" },
                    { 135, "Turquoise" },
                    { 136, "Violet" },
                    { 137, "Wheat" },
                    { 138, "WhiteSmoke" },
                    { 139, "Yellow" },
                    { 140, "YellowGreen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "variants",
                keyColumn: "Id",
                keyValue: 140);
        }
    }
}
