using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class flightinfMap : EntityTypeConfiguration<flightinf>
    {
        public flightinfMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idAirport, t.idFlight });

            // Properties
            this.Property(t => t.idAirport)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idFlight)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("flightinf", "airport");
            this.Property(t => t.idAirport).HasColumnName("idAirport");
            this.Property(t => t.idFlight).HasColumnName("idFlight");
            this.Property(t => t.type).HasColumnName("type");

            // Relationships
            this.HasRequired(t => t.airport)
                .WithMany(t => t.flightinfs)
                .HasForeignKey(d => d.idAirport);
            this.HasRequired(t => t.flight)
                .WithMany(t => t.flightinfs)
                .HasForeignKey(d => d.idFlight);

        }
    }
}
