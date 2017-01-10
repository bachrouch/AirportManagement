using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class flightMap : EntityTypeConfiguration<flight>
    {
        public flightMap()
        {
            // Primary Key
            this.HasKey(t => t.idFlight);

            // Properties
            this.Property(t => t.arrivalTime)
                .HasMaxLength(255);

            this.Property(t => t.classType)
                .HasMaxLength(255);

            this.Property(t => t.flightState)
                .HasMaxLength(255);

            this.Property(t => t.startTime)
                .HasMaxLength(255);

            this.Property(t => t.destination)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("flight", "airport");
            this.Property(t => t.idFlight).HasColumnName("idFlight");
            this.Property(t => t.arrivalTime).HasColumnName("arrivalTime");
            this.Property(t => t.classType).HasColumnName("classType");
            this.Property(t => t.flightState).HasColumnName("flightState");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.startTime).HasColumnName("startTime");
            this.Property(t => t.airline_idAirline).HasColumnName("airline_idAirline");
            this.Property(t => t.destination).HasColumnName("destination");

            // Relationships
            this.HasOptional(t => t.airline)
                .WithMany(t => t.flights)
                .HasForeignKey(d => d.airline_idAirline);

        }
    }
}
