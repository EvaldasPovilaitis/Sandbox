using Microsoft.EntityFrameworkCore.Migrations;

namespace World.Api.Migrations
{
    public partial class CoiTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryTypes",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTypes", x => new { x.CountryId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_CountryTypes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "One of eight" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Third world country" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "One of EU" });

            migrationBuilder.InsertData(
                table: "CountryTypes",
                columns: new[] { "CountryId", "TypeId" },
                values: new object[,]
                {
                    { 101, 1 },
                    { 102, 1 },
                    { 302, 1 },
                    { 101, 2 },
                    { 103, 2 },
                    { 303, 2 },
                    { 101, 3 },
                    { 301, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTypes_TypeId",
                table: "CountryTypes",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTypes");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
