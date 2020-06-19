using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace FinalArtsShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City City { get; set; }

        [ForeignKey("District")]
        public int? DistrictId { get; set; }
        public virtual District District { get; set; }
        public string Address { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.City> Cities { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Counter> Counters { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.DeliveryType> DeliveryTypes { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.District> Districts { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Follower> Followers { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Notification> Notifications { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Post> Posts { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<FinalArtsShop.Models.Slide> Slides { get; set; }
    }
}