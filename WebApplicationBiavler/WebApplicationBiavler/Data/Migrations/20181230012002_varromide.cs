using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplicationBiavler.Data.Migrations
{
    public partial class varromide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Varromides",
                columns: table => new
                {
                    Bistade = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    VarromidCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varromides", x => x.Bistade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Varromides");
        }
    }
}
