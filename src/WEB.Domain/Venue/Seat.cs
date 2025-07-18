using CSharpFunctionalExtensions;

namespace WEB.Domain.Venue
{
    public record SeatId(Guid Value);

    public class Seat
    {
        private Seat() { }

        public Seat(SeatId id, int rowNumber, int seatNumber)
        {
            Id = id;
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
        }

        public SeatId Id { get; }
        public VenueId VenueId { get; private set; }
        public int RowNumber { get; private set; }
        public int SeatNumber { get; private set; }

        public static Result<Seat> Create(int rowNumber, int seatNumber)
        {
            if (rowNumber <= 0 || seatNumber <= 0)
            {
                return Result.Failure<Seat>("seat.rowNumber");
            }

            return Result.Success(new Seat(new SeatId(Guid.NewGuid()), rowNumber, seatNumber));
        }
    }
}
