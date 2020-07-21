﻿using Microsoft.EntityFrameworkCore.Migrations;

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
               name: "Users",
               columns: table => new
               {
                   UserId = table.Column<int>(nullable: false)
                       .Annotation("Sqlite:Autoincrement", true),
                   Login = table.Column<string>(nullable: true),
                   Email = table.Column<string>(nullable: true),
                   Password = table.Column<string>(nullable: true),
                   Name = table.Column<string>(nullable: true),
                   Surname = table.Column<string>(nullable: true),
                   Patronymic = table.Column<string>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Users", x => x.UserId);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
