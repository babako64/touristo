using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightService.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatAvailable = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DestinationCityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    OriginCityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationCityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginAirportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationAirportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightSectionDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    FlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSections_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightSections_FlightId",
                table: "FlightSections",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightSections");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
