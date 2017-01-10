using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class airplaneMap : EntityTypeConfiguration<airplane>
    {
        public airplaneMap()
        {
            // Primary Key
            this.HasKey(t => t.idAirplane);

            // Properties
            this.Property(t => t.label)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("airplane", "airport");
            this.Property(t => t.idAirplane).HasColumnName("idAirplane");
            this.Property(t => t.label).HasColumnName("label");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.idTrack).HasColumnName("idTrack");
            this.Property(t => t.number).HasColumnName("number");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.airline_idAirline).HasColumnName("airline_idAirline");
            this.Property(t => t.numberTrack).HasColumnName("numberTrack");

            // Relationships
            this.HasOptional(t => t.airline)
                .WithMany(t => t.airplanes)
                .HasForeignKey(d => d.airline_idAirline);

        }
    }
}
