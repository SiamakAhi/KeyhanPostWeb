using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace keyhanPostWeb.Migrations
{
    /// <inheritdoc />
    public partial class changeOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DestinationCountryName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OriginCountryName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "TrackingCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "SenderNationalId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverNationalId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "PackageTypeId",
                table: "Orders",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "Orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "ActualWeight",
                table: "Orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<short>(
                name: "CurrentStep",
                table: "Orders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "DeliveryVehicleType",
                table: "Orders",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileForOtp",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtpCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpireAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverCompanyName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverCompanyNationalId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverEntityTypeId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverFirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverLastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverMobile",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderCompanyName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderCompanyNationalId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderEntityTypeId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderFirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderLastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderMobile",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InternationalOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageTypeId = table.Column<short>(type: "smallint", nullable: false),
                    OriginCountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationCountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    ActualWeight = table.Column<double>(type: "float", nullable: false),
                    RequesterFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequesterLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequesterMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequesterPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequesterCityId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternationalOrders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "درخواست کننده در حال ثبت اطلاعات است.", "در حال تکمیل" });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "اطلاعات سفارش تکمیل است.", "تکمیل شده" });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "سفارش بررسی شده.");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReceiverEntityTypeId",
                table: "Orders",
                column: "ReceiverEntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderEntityTypeId",
                table: "Orders",
                column: "SenderEntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalOrders_OrderStatusId",
                table: "InternationalOrders",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RepEntityTypes_ReceiverEntityTypeId",
                table: "Orders",
                column: "ReceiverEntityTypeId",
                principalTable: "RepEntityTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RepEntityTypes_SenderEntityTypeId",
                table: "Orders",
                column: "SenderEntityTypeId",
                principalTable: "RepEntityTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RepEntityTypes_ReceiverEntityTypeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RepEntityTypes_SenderEntityTypeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "InternationalOrders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReceiverEntityTypeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SenderEntityTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CurrentStep",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryVehicleType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MobileForOtp",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OtpCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OtpExpireAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverCompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverCompanyNationalId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverEntityTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverFirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverLastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverMobile",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderCompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderCompanyNationalId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderEntityTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderFirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderLastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderMobile",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrackingCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderPhone",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderNationalId",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderAddress",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverPhone",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverNationalId",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverAddress",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "PackageTypeId",
                table: "Orders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ActualWeight",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationCountryName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OriginCountryName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "سفارش ثبت شده و در صف بررسی قرار دارد.", "ارسال شده" });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "سفارش در حال پیگیری توسط کارشناس.", "در حال بررسی" });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "سفارش ثبت شده.");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
