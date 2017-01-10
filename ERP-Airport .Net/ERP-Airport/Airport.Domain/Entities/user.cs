using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Airport.Domain.Entities
{
    public partial class user : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<user> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public user()
        {
            this.claims = new List<claim>();
            this.comments = new List<comment>();
            this.reservations = new List<reservation>();
        }

        public string DTYPE { get; set; }
        // [Key]
        //public int id { get; set; }
        //public string addressMail { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        //public string password { get; set; }
        //[Display(Name = "UserName")]
        // public string username { get; set; }
        //public bool ConfirmedEmail { get; set; }
        public string grade { get; set; }
        public string nature { get; set; }
        public Nullable<System.DateTime> dateRegistration { get; set; }
        public Nullable<int> score { get; set; }
        public Nullable<int> airline_idAirline { get; set; }
        public virtual airline airline { get; set; }
        public virtual ICollection<claim> claims { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<reservation> reservations { get; set; }
        public string sexe { get; set; }

    }


}
