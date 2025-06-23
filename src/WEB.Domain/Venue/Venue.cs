using CSharpFunctionalExtensions;

namespace WEB.Domain.Venue
{
    internal class Venue
    {
        private List<Seat> _seats = [];
        public Venue(Guid id, string name, int maxSeatsCount, IEnumerable<Seat> seats)
        {
            Id = id;
            Name = name;
            SeatsLimit = maxSeatsCount;
            _seats = seats.ToList();
        }

        public Guid Id { get; }
        public string Name { get; private set; }
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
