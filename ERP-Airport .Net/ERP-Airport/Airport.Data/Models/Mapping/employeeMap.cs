using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class employeeMap : EntityTypeConfiguration<employee>
    {
        public employeeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.addressMail)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.grade)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.state)
                .HasMaxLength(255);

            this.Property(t => t.hireDate)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("employee", "airport");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.addressMail).HasColumnName("addressMail");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.grade).HasColumnName("grade");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.salary).HasColumnName("salary");
            this.Property(t => t.idEmployee).HasColumnName("idEmployee");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.hireDate).HasColumnName("hireDate");
        }
    }
}
