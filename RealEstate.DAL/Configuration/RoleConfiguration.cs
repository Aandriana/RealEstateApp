using RealEstate.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RealEstate.DAL.Configuration
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).HasMaxLength(256);
        }
    }
}
