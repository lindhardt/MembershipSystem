using System.Data.Entity;

namespace MembershipSystem.Models
{
    public class MembershipContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users")
                .Ignore(p => p.AccessFailedCount)
                .Ignore(p => p.EmailConfirmed)
                .Ignore(p => p.PhoneNumberConfirmed)
                .Ignore(p => p.TwoFactorEnabled)
                .Ignore(p => p.LockoutEnabled)
                .Ignore(p => p.LockoutEndDateUtc)
                .Ignore(p => p.Id);

            modelBuilder.Entity<Role>().ToTable("Roles")
                .Ignore(p => p.Id);

            modelBuilder.Entity<UserRole>().HasKey(k => new { k.RoleId, k.UserId }).ToTable("UserRoles");

            modelBuilder.Entity<UserLogin>().HasKey(k => k.UserId).ToTable("UserLogins");

            modelBuilder.Entity<UserClaim>().HasKey(k => k.UserId).ToTable("UserClaims");
        }

        public System.Data.Entity.DbSet<MembershipSystem.Models.UserClaim> UserClaims { get; set; }

        public System.Data.Entity.DbSet<MembershipSystem.Models.UserLogin> UserLogins { get; set; }
    }
}   