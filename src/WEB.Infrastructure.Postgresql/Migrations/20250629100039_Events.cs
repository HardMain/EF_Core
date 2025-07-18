using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Infrastructure.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class Events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seats_venues_VenueId",
                table: "seats");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "seats",
                newName: "venue_id");

            migrationBuilder.RenameIndex(
                name: "IX_seats_VenueId",
                table: "seats",
                newName: "IX_seats_venue_id");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "events",
                newName: "venue_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "venue_id",
                table: "seats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_events_venue_id",
                table: "events",
                column: "venue_id");

            migrationBuilder.AddForeignKey(
                name: "FK_events_venues_venue_id",
                table: "events",
                column: "venue_id",
                principalTable: "venues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_seats_venues_venue_id",
                table: "seats",
                column: "venue_id",
                principalTable: "venues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_venues_venue_id",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_seats_venues_venue_id",
                table: "seats");

            migrationBuilder.DropIndex(
                name: "IX_events_venue_id",
                table: "events");

            migrationBuilder.RenameColumn(
                name: "venue_id",
                table: "seats",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_seats_venue_id",
                table: "seats",
                newName: "IX_seats_VenueId");

            migrationBuilder.RenameColumn(
                name: "venue_id",
                table: "events",
                newName: "VenueId");

            migrationBuilder.AlterColumn<Guid>(
                name: "VenueId",
                table: "seats",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_venues_VenueId",
                table: "seats",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "id");
        }
    }
}
