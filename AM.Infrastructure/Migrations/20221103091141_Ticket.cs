﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class Ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    flightFK = table.Column<int>(type: "int", nullable: false),
                    numTicket = table.Column<int>(type: "int", nullable: false),
                    passengerFk = table.Column<int>(type: "int", nullable: false),
                    prix = table.Column<double>(type: "float", nullable: false),
                    siege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vip = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.flightFK, x.passengerFk, x.numTicket });
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_flightFK",
                        column: x => x.flightFK,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_passengerFk",
                        column: x => x.passengerFk,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_passengerFk",
                table: "Tickets",
                column: "passengerFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
