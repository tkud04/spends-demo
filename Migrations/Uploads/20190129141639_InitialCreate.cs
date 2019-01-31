using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpendsDemo.Migrations.Uploads
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uploads",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Fname = table.Column<string>(nullable: false),
                    UploadedBy = table.Column<string>(nullable: false),
                    dateUploaded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uploads");
        }
    }
}
