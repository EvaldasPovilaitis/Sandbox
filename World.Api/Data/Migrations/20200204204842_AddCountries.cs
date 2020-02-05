namespace World.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) => migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ContinentId", "Name" },
                values: new object[,]
                {
                    { 101, 1, "South Africa" },
                    { 702, 7, "Chile" },
                    { 701, 7, "Brazil" },
                    { 603, 6, "Mexico" },
                    { 602, 6, "Canada" },
                    { 601, 6, "United States" },
                    { 503, 5, "Lithuania" },
                    { 502, 5, "Latvia" },
                    { 501, 5, "Estonia" },
                    { 401, 4, "Australia" },
                    { 304, 3, "Indonesia" },
                    { 303, 3, "Japan" },
                    { 302, 3, "India" },
                    { 301, 3, "China" },
                    { 103, 1, "Kenya" },
                    { 102, 1, "Nigeria" },
                    { 703, 7, "Argentina" },
                    { 704, 7, "Columbia" }
                });

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 704);
        }
    }
}
