using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace keyhanPostWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentStatusIdToWayBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStatusId",
                table: "InternationalWaybill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "WaybillStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "مرسوله از مرکز پردازش مبدا خارج و به سمت فرودگاه ارسال شد.");

            migrationBuilder.UpdateData(
                table: "WaybillStatus",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "مرسوله در حال بررسی و ارزیابی توسط کارشناسان گمرک مقصد است.");

            migrationBuilder.UpdateData(
                table: "WaybillStatus",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "مرسوله توسط سفیر در حال تحویل به گیرنده است.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStatusId",
                table: "InternationalWaybill");

            migrationBuilder.UpdateData(
                table: "WaybillStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "مرسوله از مرکز مبدا خارج و به سمت فرودگاه ارسال شد.");

            migrationBuilder.UpdateData(
                table: "WaybillStatus",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "مرسوله در حال بررسی و ارزیابی توسط گمرک مقصد است.");

            migrationBuilder.UpdateData(
                table: "WaybillStatus",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "مرسوله توسط مأمور پخش در حال تحویل به گیرنده است.");
        }
    }
}
