using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAffiliate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affiliates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "NVARCHAR", nullable: false),
                    Date = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false),
                    Product = table.Column<string>(type: "NVARCHAR", nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Seller = table.Column<string>(type: "NVARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affiliates");
        }
    }
}
