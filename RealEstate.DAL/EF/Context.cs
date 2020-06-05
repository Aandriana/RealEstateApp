using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Configuration;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.EF
{
    public class RedbContext : DbContext
    {
        public RedbContext(DbContextOptions options) : base(options) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
