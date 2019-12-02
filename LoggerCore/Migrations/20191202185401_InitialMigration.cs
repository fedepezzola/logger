using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggerCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    When = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_LogTypes_Type",
                        column: x => x.Type,
                        principalTable: "LogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { "E", "Error" });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { "W", "Warning" });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { "M", "Message" });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_Type",
                table: "Logs",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "LogTypes");
        }
    }
}
