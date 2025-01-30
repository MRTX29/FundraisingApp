using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundraisingAppProcessor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReturned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Denominations_Count500 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count200 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count100 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count50 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count20 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count10 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count5 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count2 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count1 = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count50gr = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count20gr = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count10gr = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count5gr = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count2gr = table.Column<int>(type: "int", nullable: false),
                    Denominations_Count1gr = table.Column<int>(type: "int", nullable: false),
                    Denominations_OtherCurrencies = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyBoxes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
