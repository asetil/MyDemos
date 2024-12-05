using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSales.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class event_tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "EventPerformer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "EventPerformer");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Event");
        }
    }
}
