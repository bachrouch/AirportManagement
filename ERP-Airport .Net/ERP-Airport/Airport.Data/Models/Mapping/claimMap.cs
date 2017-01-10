using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class claimMap : EntityTypeConfiguration<claim>
    {
        public claimMap()
        {
            // Primary Key
            this.HasKey(t => t.idClaim);

            // Properties
            this.Property(t => t.editionDate)
                .HasMaxLength(255);

            this.Property(t => t.subject)
                .HasMaxLength(255);

            this.Property(t => t.text)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("claim", "airport");
            this.Property(t => t.idClaim).HasColumnName("idClaim");
            this.Property(t => t.editionDate).HasColumnName("editionDate");
            this.Property(t => t.subject).HasColumnName("subject");
            this.Property(t => t.text).HasColumnName("text");
            this.Property(t => t.customer_id).HasColumnName("customer_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.claims)
                .HasForeignKey(d => d.customer_id);

        }
    }
}
