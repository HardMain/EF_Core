namespace WEB.Domain.Reservation
{
    public class ReservationSeat
    {
        public ReservationSeat(Guid id, Reservation reservationId, Guid seatId)
        {
            Id = id;
            Reservation = reservationId;
            SeatId = seatId;
            ReservedAt = DateTime.UtcNow;
        }
        public Guid Id { get; }

        public Reservation Reservation { get; private set; }
        public Guid SeatId { get; private set; }
        public DateTime ReservedAt { get; }
    }
}
