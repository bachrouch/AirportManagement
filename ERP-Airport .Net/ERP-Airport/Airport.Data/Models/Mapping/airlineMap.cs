using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class airlineMap : EntityTypeConfiguration<airline>
    {
        public airlineMap()
        {
            // Primary Key
            this.HasKey(t => t.idAirline);

            // Properties
            this.Property(t => t.localAddress)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("airline", "airport");
            this.Property(t => t.idAirline).HasColumnName("idAirline");
            this.Property(t => t.localAddress).HasColumnName("localAddress");
            this.Property(t => t.name).HasColumnName("name");
        }
    }
}
