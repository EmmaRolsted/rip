using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BiWebApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //nede i vores db i vores sqlserver skal der være en tabel der hedder biavlers og inde i den skal der være kolonner fra model klassen
            migrationBuilder.CreateTable(
                name: "Biavlers",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Adress2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    DBF = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ZIPCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biavlers", x => x.Name);  //dens primary key er Name
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biavlers");
        }
    }
}
