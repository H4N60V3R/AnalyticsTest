using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsTest.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_CodeGroup",
                columns: table => new
                {
                    CG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CG_Name = table.Column<string>(maxLength: 128, nullable: false),
                    CG_Display = table.Column<string>(maxLength: 128, nullable: false),
                    CG_CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CodeGroup", x => x.CG_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_IPAddress",
                columns: table => new
                {
                    IA_ID = table.Column<int>(nullable: false),
                    IA_IP = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false),
                    IA_ContryID = table.Column<int>(nullable: false),
                    IA_CityID = table.Column<int>(nullable: false),
                    IA_ISP = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_IPAddress", x => x.IA_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Log",
                columns: table => new
                {
                    Log_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Log_Raw = table.Column<string>(nullable: false),
                    Log_DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Log", x => x.Log_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Role",
                columns: table => new
                {
                    Role_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(maxLength: 128, nullable: false),
                    Role_Display = table.Column<string>(maxLength: 128, nullable: false),
                    Role_IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Role", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Code",
                columns: table => new
                {
                    Code_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code_Name = table.Column<string>(maxLength: 128, nullable: false),
                    Code_Display = table.Column<string>(maxLength: 128, nullable: false),
                    Code_CGID = table.Column<int>(nullable: false),
                    Code_IsActive = table.Column<bool>(nullable: false),
                    Code_CreateDatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Code", x => x.Code_ID);
                    table.ForeignKey(
                        name: "FK_CodeGroup",
                        column: x => x.Code_CGID,
                        principalTable: "Tbl_CodeGroup",
                        principalColumn: "CG_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_RoleID = table.Column<int>(nullable: false),
                    User_Mobile = table.Column<string>(maxLength: 128, nullable: false),
                    User_Name = table.Column<string>(maxLength: 128, nullable: false),
                    User_Family = table.Column<string>(maxLength: 128, nullable: false),
                    User_PasswordHash = table.Column<string>(nullable: false),
                    User_PasswordSalt = table.Column<string>(nullable: false),
                    User_CreateDate = table.Column<DateTime>(nullable: false),
                    User_ModifyDate = table.Column<DateTime>(nullable: false),
                    User_IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Role",
                        column: x => x.User_RoleID,
                        principalTable: "Tbl_Role",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Visitor",
                columns: table => new
                {
                    Visitor_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visitor_IPID = table.Column<int>(nullable: false),
                    Visitor_TypeCodeID = table.Column<int>(nullable: false),
                    Visitor_CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Visitor", x => x.Visitor_ID);
                    table.ForeignKey(
                        name: "FK_IP",
                        column: x => x.Visitor_IPID,
                        principalTable: "Tbl_IPAddress",
                        principalColumn: "IA_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitorCode",
                        column: x => x.Visitor_TypeCodeID,
                        principalTable: "Tbl_Code",
                        principalColumn: "Code_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PageVisit",
                columns: table => new
                {
                    PV_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PV_VisitorID = table.Column<int>(nullable: false),
                    PV_LogID = table.Column<int>(nullable: false),
                    PV_PageUrl = table.Column<string>(nullable: false),
                    PV_Referrer = table.Column<string>(nullable: true),
                    PV_WindowSize = table.Column<string>(maxLength: 50, nullable: true),
                    PV_BrowerCodeID = table.Column<int>(nullable: true),
                    PV_BrowerInfo = table.Column<string>(nullable: true),
                    PV_PlatformCodeID = table.Column<int>(nullable: true),
                    PV_UserAgent = table.Column<string>(nullable: true),
                    PV_DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PageVisit", x => x.PV_ID);
                    table.ForeignKey(
                        name: "FK_BrowerCode",
                        column: x => x.PV_BrowerCodeID,
                        principalTable: "Tbl_Code",
                        principalColumn: "Code_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log",
                        column: x => x.PV_LogID,
                        principalTable: "Tbl_Log",
                        principalColumn: "Log_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlatformCode",
                        column: x => x.PV_PlatformCodeID,
                        principalTable: "Tbl_Code",
                        principalColumn: "Code_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitor",
                        column: x => x.PV_VisitorID,
                        principalTable: "Tbl_Visitor",
                        principalColumn: "Visitor_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Session",
                columns: table => new
                {
                    Session_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session_Guid = table.Column<Guid>(nullable: false),
                    Session_StartDateTime = table.Column<DateTime>(nullable: false),
                    Session_LastDateTime = table.Column<DateTime>(nullable: false),
                    Session_VisitorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Session", x => x.Session_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Session_Tbl_Visitor",
                        column: x => x.Session_VisitorID,
                        principalTable: "Tbl_Visitor",
                        principalColumn: "Visitor_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Code_Code_CGID",
                table: "Tbl_Code",
                column: "Code_CGID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PageVisit_PV_BrowerCodeID",
                table: "Tbl_PageVisit",
                column: "PV_BrowerCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PageVisit_PV_LogID",
                table: "Tbl_PageVisit",
                column: "PV_LogID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PageVisit_PV_PlatformCodeID",
                table: "Tbl_PageVisit",
                column: "PV_PlatformCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PageVisit_PV_VisitorID",
                table: "Tbl_PageVisit",
                column: "PV_VisitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Session_Session_VisitorID",
                table: "Tbl_Session",
                column: "Session_VisitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_User_User_RoleID",
                table: "Tbl_User",
                column: "User_RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Visitor_Visitor_IPID",
                table: "Tbl_Visitor",
                column: "Visitor_IPID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Visitor_Visitor_TypeCodeID",
                table: "Tbl_Visitor",
                column: "Visitor_TypeCodeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_PageVisit");

            migrationBuilder.DropTable(
                name: "Tbl_Session");

            migrationBuilder.DropTable(
                name: "Tbl_User");

            migrationBuilder.DropTable(
                name: "Tbl_Log");

            migrationBuilder.DropTable(
                name: "Tbl_Visitor");

            migrationBuilder.DropTable(
                name: "Tbl_Role");

            migrationBuilder.DropTable(
                name: "Tbl_IPAddress");

            migrationBuilder.DropTable(
                name: "Tbl_Code");

            migrationBuilder.DropTable(
                name: "Tbl_CodeGroup");
        }
    }
}
