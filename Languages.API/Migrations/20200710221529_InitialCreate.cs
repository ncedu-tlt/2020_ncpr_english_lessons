using Api.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    ChatID = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    ProfID = table.Column<int>(nullable: true),
                    StudID = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.ChatID);
                });
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    RecordID = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    IDs = table.Column<Chat>(nullable: true),
                    SenderID = table.Column<int[]>(nullable: true),
                    SenderMessage = table.Column<string>(nullable: true),
                    TimeWhenSent = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                  table.PrimaryKey("PK_Messages", x => x.RecordID);
                }
                );
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "Messages");


        }
    }
}
