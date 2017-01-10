using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class commentMap : EntityTypeConfiguration<comment>
    {
        public commentMap()
        {
            // Primary Key
            this.HasKey(t => t.idComment);

            // Properties
            this.Property(t => t.text)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("comment", "airport");
            this.Property(t => t.idComment).HasColumnName("idComment");
            this.Property(t => t.editionDate).HasColumnName("editionDate");
            this.Property(t => t.text).HasColumnName("text");
            this.Property(t => t.customer_id).HasColumnName("customer_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.customer_id);

        }
    }
}
