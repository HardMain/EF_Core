using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Infrastructure.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class RenameReservationSeatsSeatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_seat_seats_SeatId",
                table: "reservation_seat");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "reservation_seat",
                newName: "seat_id");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_seat_SeatId",
                table: "reservation_seat",
                newName: "IX_reservation_seat_seat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_seat_seats_seat_id",
                table: "reservation_seat",
                column: "seat_id",
                principalTable: "seats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_seat_seats_seat_id",
                table: "reservation_seat");

            migrationBuilder.RenameColumn(
                name: "seat_id",
                table: "reservation_seat",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_seat_seat_id",
                table: "reservation_seat",
                newName: "IX_reservation_seat_SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_seat_seats_SeatId",
                table: "reservation_seat",
                column: "SeatId",
                principalTable: "seats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
