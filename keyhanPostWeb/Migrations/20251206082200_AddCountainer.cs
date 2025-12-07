using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace keyhanPostWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCountainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaybillCounter",
                table: "InternationalWaybill",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaybillCounter",
                table: "InternationalWaybill");
        }
    }
}
