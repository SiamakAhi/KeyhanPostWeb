using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace keyhanPostWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddWayBillModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternationalWaybill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaybillNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageCount = table.Column<int>(type: "int", nullable: false),
                    PackageWeight = table.Column<double>(type: "float", nullable: false),
                    OriginCountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationCountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalWaybill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaybillStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaybillStatusHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaybillId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillStatusHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaybillStatusHistory_InternationalWaybill_WaybillId",
                        column: x => x.WaybillId,
                        principalTable: "InternationalWaybill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WaybillStatusHistory_WaybillStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "WaybillStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "WaybillStatus",
                columns: new[] { "Id", "Description", "Title", "TitleEn" },
                values: new object[,]
                {
                    { 1, "در حال تماس و هماهنگی اولیه با فرستنده مرسوله.", "ارتباط با فرستنده", "Communication with the sender" },
                    { 2, "بسته از فرستنده تحویل گرفته شد و فرآیند ارسال آغاز گردید.", "دريافت مرسوله", "Received shipment" },
                    { 3, "مرسوله وارد مرکز پردازش مبدا شد و در حال بررسی و ثبت است.", "ورود مرسوله به هاب مبدا", "Shipment entered the origin hub" },
                    { 4, "مرسوله از مرکز مبدا خارج و به سمت فرودگاه ارسال شد.", "خروج از هاب به فرودگاه", "Departed from the hub to the airport" },
                    { 5, "مرسوله کشور مبدا را ترک کرد و در مسیر پرواز قرار گرفت.", "خروج از فرودگاه", "Departed from the airport" },
                    { 6, "مرسوله وارد فرودگاه کشور مقصد شد.", "ورود به فرودگاه مقصد", "Arrived at the destination airport" },
                    { 7, "مرسوله در حال بررسی و ارزیابی توسط گمرک مقصد است.", "در حال ارزیابی گمرک", "Under customs assessment" },
                    { 8, "مرسوله از گمرک مقصد ترخیص شد.", "خروج از گمرک", "Departed from customs" },
                    { 9, "مرسوله وارد مرکز پردازش مقصد شد و آماده ارسال نهایی است.", "ورود به هاب مقصد", "Arrived at the destination hub" },
                    { 10, "مرسوله توسط مأمور پخش در حال تحویل به گیرنده است.", "در حال تحويل دادن", "Delivering" },
                    { 11, "مرسوله با موفقیت به گیرنده نهایی تحویل داده شد.", "تحويل داده شد", "Delivered" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaybillStatusHistory_StatusId",
                table: "WaybillStatusHistory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillStatusHistory_WaybillId",
                table: "WaybillStatusHistory",
                column: "WaybillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaybillStatusHistory");

            migrationBuilder.DropTable(
                name: "InternationalWaybill");

            migrationBuilder.DropTable(
                name: "WaybillStatus");
        }
    }
}
