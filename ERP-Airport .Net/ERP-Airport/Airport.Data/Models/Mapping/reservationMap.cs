using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class reservationMap : EntityTypeConfiguration<reservation>
    {
        public reservationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.arrivalDate)
                .HasMaxLength(255);

            this.Property(t => t.departureDate)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("reservation", "airport");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.arrivalDate).HasColumnName("arrivalDate");
            this.Property(t => t.departureDate).HasColumnName("departureDate");
            this.Property(t => t.reservationState).HasColumnName("reservationState");
            this.Property(t => t.customer_id).HasColumnName("customer_id");
            this.Property(t => t.flight_idFlight).HasColumnName("flight_idFlight");

            // Relationships
            this.HasOptional(t => t.flight)
                .WithMany(t => t.reservations)
                .HasForeignKey(d => d.flight_idFlight);
            this.HasOptional(t => t.user)
                .WithMany(t => t.reservations)
                .HasForeignKey(d => d.customer_id);

        }
    }
}
