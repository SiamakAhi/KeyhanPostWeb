using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace keyhanPostWeb.Migrations
{
    /// <inheritdoc />
    public partial class MakePackageTypeIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "PackageTypeId",
                table: "InternationalOrders",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "PackageTypeId",
                table: "InternationalOrders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }
    }
}
