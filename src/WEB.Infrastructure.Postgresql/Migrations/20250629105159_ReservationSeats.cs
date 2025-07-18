using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Infrastructure.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class ReservationSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_seat_reservations_ReservationId",
                table: "reservation_seat");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "reservation_seat",
                newName: "reservation_id");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_seat_ReservationId",
                table: "reservation_seat",
                newName: "IX_reservation_seat_reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_seat_SeatId",
                table: "reservation_seat",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_seat_reservations_reservation_id",
                table: "reservation_seat",
                column: "reservation_id",
                principalTable: "reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_seat_seats_SeatId",
                table: "reservation_seat",
                column: "SeatId",
                principalTable: "seats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_seat_reservations_reservation_id",
                table: "reservation_seat");

            migrationBuilder.DropForeignKey(
                name: "FK_reservation_seat_seats_SeatId",
                table: "reservation_seat");

            migrationBuilder.DropIndex(
                name: "IX_reservation_seat_SeatId",
                table: "reservation_seat");

            migrationBuilder.RenameColumn(
                name: "reservation_id",
                table: "reservation_seat",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_seat_reservation_id",
                table: "reservation_seat",
                newName: "IX_reservation_seat_ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_seat_reservations_ReservationId",
                table: "reservation_seat",
                column: "ReservationId",
                principalTable: "reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
