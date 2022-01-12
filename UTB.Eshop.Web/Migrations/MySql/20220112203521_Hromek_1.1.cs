using Microsoft.EntityFrameworkCore.Migrations;

namespace UTB.Eshop.Web.Migrations.MySql
{
    public partial class Hromek_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProductID",
                table: "Rating",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Product_ProductID",
                table: "Rating",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Product_ProductID",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ProductID",
                table: "Rating");
        }
    }
}
