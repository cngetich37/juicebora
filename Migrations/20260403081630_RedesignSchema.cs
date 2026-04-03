using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace juicebora.Migrations
{
    /// <inheritdoc />
    public partial class RedesignSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_OrderId",
                table: "Sales",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_JuiceId",
                table: "OrderItems",
                column: "JuiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JuiceIngredients_IngredientId",
                table: "JuiceIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_JuiceIngredients_JuiceId",
                table: "JuiceIngredients",
                column: "JuiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuiceIngredients_Ingredients_IngredientId",
                table: "JuiceIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JuiceIngredients_Juices_JuiceId",
                table: "JuiceIngredients",
                column: "JuiceId",
                principalTable: "Juices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Juices_JuiceId",
                table: "OrderItems",
                column: "JuiceId",
                principalTable: "Juices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuiceIngredients_Ingredients_IngredientId",
                table: "JuiceIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_JuiceIngredients_Juices_JuiceId",
                table: "JuiceIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Juices_JuiceId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_OrderId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_JuiceId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_JuiceIngredients_IngredientId",
                table: "JuiceIngredients");

            migrationBuilder.DropIndex(
                name: "IX_JuiceIngredients_JuiceId",
                table: "JuiceIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
