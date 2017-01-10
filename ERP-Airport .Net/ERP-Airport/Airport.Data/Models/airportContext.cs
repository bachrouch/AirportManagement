using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Airport.Data.Models.Mapping;
using Airport.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airport.Data.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class airportContext : IdentityDbContext<user>
    {
        public airportContext() : base("airportContext")
        {

        }

        public static airportContext Create()
        {

            return new airportContext();
        }

        static airportContext()
           {
            Database.SetInitializer<airportContext>(null);
        }



        public DbSet<airline> airlines { get; set; }
        public DbSet<airplane> airplanes { get; set; }
        public DbSet<airport> airports { get; set; }
        public DbSet<claim> claims { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<flight> flights { get; set; }
        public DbSet<flightinf> flightinfs { get; set; }
        public DbSet<reservation> reservations { get; set; }
        public DbSet<stopover> stopovers { get; set; }
        //public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
            modelBuilder.Configurations.Add(new airlineMap());
            modelBuilder.Configurations.Add(new airplaneMap());
            modelBuilder.Configurations.Add(new airportMap());
            modelBuilder.Configurations.Add(new claimMap());
            modelBuilder.Configurations.Add(new commentMap());
            modelBuilder.Configurations.Add(new employeeMap());
            modelBuilder.Configurations.Add(new flightMap());
            modelBuilder.Configurations.Add(new flightinfMap());
            modelBuilder.Configurations.Add(new reservationMap());
            modelBuilder.Configurations.Add(new stopoverMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

    }
}
