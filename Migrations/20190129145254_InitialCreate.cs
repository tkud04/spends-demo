using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpendsDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spends",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Media = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Quarter = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Advertizer = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Station = table.Column<string>(nullable: false),
                    TVRadio = table.Column<int>(nullable: false),
                    Days = table.Column<string>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TimeBand = table.Column<string>(nullable: true),
                    TimeSlot = table.Column<string>(nullable: true),
                    Print = table.Column<int>(nullable: false),
                    AverageDuration = table.Column<int>(nullable: false),
                    AdSize = table.Column<string>(nullable: true),
                    TotalSpend = table.Column<string>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spends", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spends");
        }
    }
}
