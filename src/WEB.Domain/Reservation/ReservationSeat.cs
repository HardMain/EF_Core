using WEB.Domain.Venue;

namespace WEB.Domain.Reservation
{
    public record ReservationSeatId(Guid Value);

    public class ReservationSeat
    {
        private ReservationSeat()
        {
            
        }

        public ReservationSeat(ReservationSeatId id, Reservation reservationId, SeatId seatId)
        {
            Id = id;
            Reservation = reservationId;
            SeatId = seatId;
            ReservedAt = DateTime.UtcNow;
        }
        public ReservationSeatId Id { get; }
        public Reservation Reservation { get; private set; }
        public SeatId SeatId { get; private set; }
        public DateTime ReservedAt { get; }
    }
}
