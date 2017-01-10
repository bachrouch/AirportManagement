using Airport.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Airport.Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            // this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            // this.Property(t => t.addressMail)
            //   .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            // this.Property(t => t.password)
            //   .HasMaxLength(255);

            //  this.Property(t => t.username)
            //:     .HasMaxLength(255);

            this.Property(t => t.grade)
                .HasMaxLength(255);

            this.Property(t => t.nature)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user", "airport");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            // this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.Email).HasColumnName("addressMail");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            // this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.PasswordHash).HasColumnName("password");
            this.Property(t => t.UserName).HasColumnName("username");
            this.Property(t => t.grade).HasColumnName("grade");
            this.Property(t => t.nature).HasColumnName("nature");
            this.Property(t => t.dateRegistration).HasColumnName("dateRegistration");
            this.Property(t => t.score).HasColumnName("score");
            this.Property(t => t.airline_idAirline).HasColumnName("airline_idAirline");

            // Relationships
            this.HasOptional(t => t.airline)
                .WithMany(t => t.users)
                .HasForeignKey(d => d.airline_idAirline);

        }
    }
}
  