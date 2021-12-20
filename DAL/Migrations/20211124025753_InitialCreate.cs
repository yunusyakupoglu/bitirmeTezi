using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blogAppUserStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogAppUserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objAppRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objAppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objAppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objAppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "getDate()"),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objBlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objAppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objAppUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_objAppUserRoles_objAppRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "objAppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objAppUserRoles_objAppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "objAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blogAppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    ObjBlogId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ObjAppUserId = table.Column<int>(type: "int", nullable: true),
                    BlogAppUserStatusId = table.Column<int>(type: "int", nullable: false),
                    ObjBlogAppUserStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogAppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogAppUsers_blogAppUserStatuses_ObjBlogAppUserStatusId",
                        column: x => x.ObjBlogAppUserStatusId,
                        principalTable: "blogAppUserStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blogAppUsers_objAppUsers_ObjAppUserId",
                        column: x => x.ObjAppUserId,
                        principalTable: "objAppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blogAppUsers_objBlogs_ObjBlogId",
                        column: x => x.ObjBlogId,
                        principalTable: "objBlogs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "objAppRoles",
                columns: new[] { "Id", "Definition", "Status" },
                values: new object[] { 1, "SuperAdmin", false });

            migrationBuilder.InsertData(
                table: "objAppRoles",
                columns: new[] { "Id", "Definition", "Status" },
                values: new object[] { 2, "Admin", false });

            migrationBuilder.InsertData(
                table: "objAppRoles",
                columns: new[] { "Id", "Definition", "Status" },
                values: new object[] { 3, "Member", false });

            migrationBuilder.CreateIndex(
                name: "IX_blogAppUsers_ObjAppUserId",
                table: "blogAppUsers",
                column: "ObjAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_blogAppUsers_ObjBlogAppUserStatusId",
                table: "blogAppUsers",
                column: "ObjBlogAppUserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_blogAppUsers_ObjBlogId",
                table: "blogAppUsers",
                column: "ObjBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_objAppUserRoles_AppRoleId_AppUserId",
                table: "objAppUserRoles",
                columns: new[] { "AppRoleId", "AppUserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objAppUserRoles_AppUserId",
                table: "objAppUserRoles",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogAppUsers");

            migrationBuilder.DropTable(
                name: "objAppUserRoles");

            migrationBuilder.DropTable(
                name: "blogAppUserStatuses");

            migrationBuilder.DropTable(
                name: "objBlogs");

            migrationBuilder.DropTable(
                name: "objAppRoles");

            migrationBuilder.DropTable(
                name: "objAppUsers");
        }
    }
}
