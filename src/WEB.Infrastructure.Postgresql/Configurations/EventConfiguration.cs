using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Domain.Events;
using WEB.Domain.Venue;

namespace WEB.Infrastructure.Postgresql.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");

            builder
                .HasKey(e => e.Id)
                .HasName("pk_event");

            builder
                .Property(e => e.Id)
                .HasConversion(e => e.Value, idb => new EventId(idb))
                .HasColumnName("id");

            builder
                .HasOne<Venue>()
                .WithMany()
                .HasForeignKey(e => e.VenueId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(e => e.VenueId)
                .HasColumnName("venue_id");
        }
    }
}
