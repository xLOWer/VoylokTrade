using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoylokTrade.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BoxSize = table.Column<int>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    MinOrger = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WeightInGramms = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");
        }
    }
}
