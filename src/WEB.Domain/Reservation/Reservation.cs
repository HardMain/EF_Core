using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Domain.Reservation
{
    public class Reservation
    {
        private List<ReservationSeat> _reservedSeats;
        public Reservation(Guid id, Guid eventId, Guid userId, IEnumerable<Guid> seatIds)
        {
            Id = id;
            Status = ReservationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            EventId = eventId;
            UserId = userId;

            _reservedSeats = seatIds
                .Select(id => new ReservationSeat(Guid.NewGuid(), this, id))
                .ToList();
        }

        public Guid Id { get; private set; }
        public Guid EventId { get; private set; }
        public Guid UserId { get; private set; }
        public ReservationStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyList<ReservationSeat> Seats => _reservedSeats;
    }
}
