using WEB.Domain.Venue;

namespace WEB.Domain.Reservation
{
    public record ReservationId(Guid Value);
    public class Reservation
    {
        private List<ReservationSeat> _reservedSeats;
        private Reservation()
        {
            
        }

        public Reservation(ReservationId id, Guid eventId, Guid userId, IEnumerable<Guid> seatIds)
        {
            Id = id;
            Status = ReservationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            EventId = eventId;
            UserId = userId;

            _reservedSeats = seatIds
                .Select(id => new ReservationSeat(new ReservationSeatId(Guid.NewGuid()), this, new SeatId(id)))
                .ToList();
        }

        public ReservationId Id { get; private set; } = null!;
        public Guid EventId { get; private set; }
        public Guid UserId { get; private set; }
        public ReservationStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyList<ReservationSeat> Seats => _reservedSeats;
    }
}
