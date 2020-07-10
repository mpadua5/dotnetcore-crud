using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetCoreCrud.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    guid = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(type: "varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    guid = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(type: "varchar(128)", nullable: false),
                    unit_value = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    amount = table.Column<float>(type: "float(6,3)", nullable: false),
                    unity = table.Column<string>(type: "char(3)", nullable: false),
                    category = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Product_Category_category",
                        column: x => x.category,
                        principalTable: "Category",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_category",
                table: "Product",
                column: "category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
