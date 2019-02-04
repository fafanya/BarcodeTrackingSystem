using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Service.Migrations
{
    public partial class DBMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoutePoints",
                columns: table => new
                {
                    RoutePointId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePoints", x => x.RoutePointId);
                });

            migrationBuilder.CreateTable(
                name: "RouteSheets",
                columns: table => new
                {
                    RouteSheetId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Barcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteSheets", x => x.RouteSheetId);
                });

            migrationBuilder.CreateTable(
                name: "RouteMarks",
                columns: table => new
                {
                    RouteMarkId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Stamp = table.Column<DateTime>(nullable: false),
                    RouteSheetId = table.Column<int>(nullable: false),
                    RoutePointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteMarks", x => x.RouteMarkId);
                    table.ForeignKey(
                        name: "FK_RouteMarks_RoutePoints_RoutePointId",
                        column: x => x.RoutePointId,
                        principalTable: "RoutePoints",
                        principalColumn: "RoutePointId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteMarks_RouteSheets_RouteSheetId",
                        column: x => x.RouteSheetId,
                        principalTable: "RouteSheets",
                        principalColumn: "RouteSheetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteMarks_RoutePointId",
                table: "RouteMarks",
                column: "RoutePointId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteMarks_RouteSheetId",
                table: "RouteMarks",
                column: "RouteSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteMarks");

            migrationBuilder.DropTable(
                name: "RoutePoints");

            migrationBuilder.DropTable(
                name: "RouteSheets");
        }
    }
}
