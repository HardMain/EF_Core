using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Domain.Reservation;

namespace WEB.Infrastructure.Postgresql.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("reservations");

            builder
                .HasKey(r => r.Id)
                .HasName("pk_reservations");

            builder
                .Property(r => r.Id)
                .HasConversion(r => r.Value, idb => new ReservationId(idb))
                .HasColumnName("id");

            //builder
            //    .HasMany(r => r.Seats)
            //    .WithOne(rs => rs.Reservation)
            //    .HasForeignKey(rs => rs.SeatId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}