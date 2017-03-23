using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wedding.Migrations
{
    public partial class SpouseTitle2ndToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SndSpouseTitle",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpouseTitle",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SndSpouseTitle",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "SpouseTitle",
                table: "Event");
        }
    }
}
