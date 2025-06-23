using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace WEB.Domain.Venue
{
    internal class Seat
    {
        public Seat(Guid id, int rowNumber, int seatNumber)
        {
            Id = id;
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
        }

        public Guid Id { get; }
        public int RowNumber { get; private set; }
        public int SeatNumber { get; private set; }

        public static Result<Seat> Create(int rowNumber, int seatNumber)
        {
            if (rowNumber <= 0 || seatNumber <= 0)
            {
                return Result.Failure<Seat>("seat.rowNumber");
            }

            return Result.Success(new Seat(Guid.NewGuid(), rowNumber, seatNumber));
        }
    }
}
