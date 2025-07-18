using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Domain.Reservation;
using WEB.Domain.Venue;

namespace WEB.Infrastructure.Postgresql.Configurations
{
    public class ReservationSeatConfiguration : IEntityTypeConfiguration<ReservationSeat>
    {
        public void Configure(EntityTypeBuilder<ReservationSeat> builder)
        {
            builder.ToTable("reservation_seat");

            builder
                .HasKey(r => r.Id)
                .HasName("pk_reservation_seat");

            builder
                .Property(r => r.Id)
                .HasConversion(r => r.Value, id => new ReservationSeatId(id))
                .HasColumnName("id");

            builder
                .HasOne(rs => rs.Reservation)
                .WithMany(r => r.Seats)
                .HasForeignKey("reservation_id")  
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne<Seat>()
                .WithMany()
                .HasForeignKey(rs => rs.SeatId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(rs => rs.SeatId)
                .HasColumnName("seat_id");
        }
    }
}
