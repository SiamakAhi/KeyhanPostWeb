using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace keyhanPostWeb.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusMapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "سفارش ثبت شده و در صف بررسی قرار دارد.", "ارسال شده" },
                    { 2, "سفارش در حال پیگیری توسط کارشناس.", "در حال بررسی" },
                    { 3, "سفارش ثبت شده.", "بررسی شده" },
                    { 4, "سفارش لغو شده است.", "لغو شده" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
