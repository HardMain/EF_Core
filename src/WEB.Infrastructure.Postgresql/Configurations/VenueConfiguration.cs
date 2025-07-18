using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Domain.Venue;
using WEB.Domain.Shared;

namespace WEB.Infrastructure.Postgresql.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToTable("venues");

            builder
                .HasKey(v => v.Id)
                .HasName("pk_venues");

            builder
                .Property(v => v.Id)
                .HasConversion(v => v.Value, id => new VenueId(id))
                .HasColumnName("id");

            builder.ComplexProperty(v => v.Name, nb =>
            {
                nb.Property(v => v.Prefix)
                    .IsRequired()
                    .HasMaxLength(LengthConstants.LENGTH50)
                    .HasColumnName("prefix");

                nb.Property(v => v.Name)
                    .IsRequired()
                    .HasMaxLength(LengthConstants.LENGTH500)
                    .HasColumnName("name"); 
            });

            builder
                .HasMany(v => v.Seats)
                .WithOne()
                .HasForeignKey(s => s.VenueId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
