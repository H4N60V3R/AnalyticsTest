using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsTest.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitingLogs",
                columns: table => new
                {
                    VisitLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitingLogs", x => x.VisitLogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitingLogs");
        }
    }
}
