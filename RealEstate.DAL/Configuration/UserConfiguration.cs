using RealEstate.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstate.DAL.Configuration
{
    class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PasswordHash).HasMaxLength(256);
            builder.HasOne(u => u.UserProfile).WithOne(u => u.User).HasForeignKey<UserProfile>(x => x.Id).IsRequired();
            builder.HasOne(u => u.Role).WithMany().HasForeignKey(u => u.RoleId);
        }
    }
}
