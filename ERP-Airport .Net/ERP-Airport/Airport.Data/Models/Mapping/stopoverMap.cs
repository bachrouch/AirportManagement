using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class stopoverMap : EntityTypeConfiguration<stopover>
    {
        public stopoverMap()
        {
            // Primary Key
            this.HasKey(t => t.idStopOver);

            // Properties
            // Table & Column Mappings
            this.ToTable("stopover", "airport");
            this.Property(t => t.idStopOver).HasColumnName("idStopOver");
            this.Property(t => t.arrivalTime).HasColumnName("arrivalTime");
            this.Property(t => t.startTime).HasColumnName("startTime");
            this.Property(t => t.flight_idFlight).HasColumnName("flight_idFlight");

            // Relationships
            this.HasOptional(t => t.flight)
                .WithMany(t => t.stopovers)
                .HasForeignKey(d => d.flight_idFlight);

        }
    }
}
