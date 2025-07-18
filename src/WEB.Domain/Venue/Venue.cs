using CSharpFunctionalExtensions;

namespace WEB.Domain.Venue
{
    public record VenueId(Guid Value);

    public class Venue
    {
        private Venue() { }

        private List<Seat> _seats = [];
        public Venue(VenueId id, VenueName name, int maxSeatsCount, IEnumerable<Seat> seats)
        {
            Id = id;
            Name = name;
            SeatsLimit = maxSeatsCount; 
            _seats = seats.ToList();
        }

        public VenueId Id { get; } = null!;
        public VenueName Name { get; } = null!;
        public int SeatsLimit { get; private set; }
        public int SeatsCount => _seats.Count();
        public IReadOnlyList<Seat> Seats => _seats;

        public UnitResult<string> AddSeat(Seat seat)
        {
            if (SeatsCount >= SeatsLimit)
            {
                return UnitResult.Failure("venue.seats.limit");
            }
            _seats.Add(seat);

            return UnitResult.Success<string>();
        }
        public void ExpandSeatsLimit(int newSeatsLimit) => SeatsLimit = newSeatsLimit;
    }
}
