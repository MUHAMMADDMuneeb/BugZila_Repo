using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugZila.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Users_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Bugs",
                columns: table => new
                {
                    BugID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false),
                    DeveloperID = table.Column<int>(type: "int", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    Screenshot = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugs", x => x.BugID);
                    table.ForeignKey(
                        name: "FK_Bugs_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugs_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugs_Users_DeveloperID",
                        column: x => x.DeveloperID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUsers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsers", x => new { x.UserID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_CreatorID",
                table: "Bugs",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_DeveloperID",
                table: "Bugs",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_ProjectID_Title",
                table: "Bugs",
                columns: new[] { "ProjectID", "Title" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ManagerID",
                table: "Projects",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectID",
                table: "ProjectUsers",
                column: "ProjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bugs");

            migrationBuilder.DropTable(
                name: "ProjectUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
