using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunningApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunningInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Distance = table.Column<double>(type: "REAL", nullable: false),
                    Tempo = table.Column<int>(type: "INTEGER", nullable: false),
                    Track = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePicture = table.Column<string>(type: "TEXT", nullable: true),
                    RunningInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_RunningInfos_RunningInfoId",
                        column: x => x.RunningInfoId,
                        principalTable: "RunningInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RunningPointInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RunningInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    X = table.Column<double>(type: "REAL", nullable: false),
                    Y = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningPointInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunningPointInfos_RunningInfos_RunningInfoId",
                        column: x => x.RunningInfoId,
                        principalTable: "RunningInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RunningPointInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunningInfos_UserId",
                table: "RunningInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningPointInfos_RunningInfoId",
                table: "RunningPointInfos",
                column: "RunningInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningPointInfos_UserId",
                table: "RunningPointInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RunningInfoId",
                table: "Users",
                column: "RunningInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RunningInfos_Users_UserId",
                table: "RunningInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunningInfos_Users_UserId",
                table: "RunningInfos");

            migrationBuilder.DropTable(
                name: "RunningPointInfos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RunningInfos");
        }
    }
}
