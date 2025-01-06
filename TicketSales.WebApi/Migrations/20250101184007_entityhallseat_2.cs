using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketSales.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class entityhallseat_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaceHallSeat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    Column = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Block = table.Column<int>(type: "integer", nullable: false),
                    PlaceHallId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreated = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserModified = table.Column<long>(type: "bigint", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceHallSeat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceHallSeat_PlaceHall_PlaceHallId",
                        column: x => x.PlaceHallId,
                        principalTable: "PlaceHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTicket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventSessionId = table.Column<long>(type: "bigint", nullable: false),
                    HallSeatId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PurchaseTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserCreated = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserModified = table.Column<long>(type: "bigint", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTicket_EventSession_EventSessionId",
                        column: x => x.EventSessionId,
                        principalTable: "EventSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicket_PlaceHallSeat_HallSeatId",
                        column: x => x.HallSeatId,
                        principalTable: "PlaceHallSeat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicket_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTicket_EventSessionId",
                table: "EventTicket",
                column: "EventSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicket_HallSeatId",
                table: "EventTicket",
                column: "HallSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicket_UserId",
                table: "EventTicket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceHallSeat_PlaceHallId",
                table: "PlaceHallSeat",
                column: "PlaceHallId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTicket");

            migrationBuilder.DropTable(
                name: "PlaceHallSeat");
        }
    }
}
