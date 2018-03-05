using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoylokTrade.Migrations
{
    public partial class EditedGoodModelForActualPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxSize",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "WeightInGramms",
                table: "Goods",
                newName: "TareVolume");

            migrationBuilder.RenameColumn(
                name: "MinOrger",
                table: "Goods",
                newName: "PriceMarkupInPercent");

            migrationBuilder.AddColumn<double>(
                name: "PricePerGood",
                table: "Goods",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Goods",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Goods",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightType",
                table: "Goods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerGood",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "WeightType",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "TareVolume",
                table: "Goods",
                newName: "WeightInGramms");

            migrationBuilder.RenameColumn(
                name: "PriceMarkupInPercent",
                table: "Goods",
                newName: "MinOrger");

            migrationBuilder.AddColumn<int>(
                name: "BoxSize",
                table: "Goods",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Goods",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
