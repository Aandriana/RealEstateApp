using RealEstate.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstate.DAL.Configuration
{
    class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure (EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UsersProfiles");
            builder.Property(u => u.FirstName).HasMaxLength(32);
            builder.Property(u => u.LastName).HasMaxLength(32);
            builder.Property(u => u.PhoneNumber).HasMaxLength(32);
        }
    }
}
