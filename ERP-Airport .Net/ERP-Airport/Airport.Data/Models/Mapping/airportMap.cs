using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class airportMap : EntityTypeConfiguration<airport>
    {
        public airportMap()
        {
            // Primary Key
            this.HasKey(t => t.idAirport);

            // Properties
            this.Property(t => t.city)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("airport", "airport");
            this.Property(t => t.idAirport).HasColumnName("idAirport");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.country).HasColumnName("country");
        }
    }
}
