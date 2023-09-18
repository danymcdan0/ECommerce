using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Public : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Baskets_BasketID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BasketID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductDTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    BasketID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDTO_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDTO_BasketID",
                table: "ProductDTO",
                column: "BasketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDTO");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BasketID",
                table: "Products",
                column: "BasketID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Baskets_BasketID",
                table: "Products",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID");
        }
    }
}
