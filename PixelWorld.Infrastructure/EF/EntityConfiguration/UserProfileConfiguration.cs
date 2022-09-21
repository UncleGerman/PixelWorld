using PixelWorld.DAL.Entity.Identity;
using System.Data.Entity.ModelConfiguration;

namespace PixelWorld.Infrastructure.EF.EntityConfiguration
{
    internal sealed class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        internal UserProfileConfiguration()
        {
            EntityTypeConfiguration<UserProfile> tableName = ToTable(tableName: nameof(UserProfile));

            tableName.HasMany(u => u.Inventory);
            tableName.HasMany(u => u.Orders);

            tableName.Property(c => c.Name)
                                 .IsRequired()
                                 .HasMaxLength(20);

            tableName.Property(c => c.Email)
                                 .IsRequired()
                                 .HasMaxLength(20);
        }
    }
}
