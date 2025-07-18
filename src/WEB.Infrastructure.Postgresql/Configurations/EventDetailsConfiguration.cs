using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Domain.Events;

namespace WEB.Infrastructure.Postgresql.Configurations
{
    public class EventDetailsConfiguration : IEntityTypeConfiguration<EventDetails>
    {
        public void Configure(EntityTypeBuilder<EventDetails> builder)
        {
            builder.ToTable("events_details");

            builder
                .HasKey(e => e.EventId)
                .HasName("pk_event_details");

            builder
                .Property(e => e.EventId)
                .HasConversion(e => e.Value, idb => new EventId(idb))
                .HasColumnName("event_id");

            builder
                .HasOne<Event>()
                .WithOne(e => e.Details)
                .HasForeignKey<EventDetails>(e => e.EventId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
