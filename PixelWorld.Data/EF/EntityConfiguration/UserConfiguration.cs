using PixelWorld.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PixelWorld.Data.EF.EntityConfiguration
{
    internal sealed class UserConfiguration : EntityTypeConfiguration<User>
    {
        internal UserConfiguration()
        {
            EntityTypeConfiguration<User> tableName = ToTable(tableName: nameof(User));

            tableName.HasMany(u => u.Inventory);
            tableName.HasMany(u => u.Orders);

            tableName.HasKey(u => u.Id);

            tableName.Property(c => c.Name)
                                 .IsRequired()
                                 .HasMaxLength(20);

            tableName.Property(c => c.Email)
                                 .IsRequired()
                                 .HasMaxLength(20);

            tableName.Property(c => c.Password)
                                 .IsRequired()
                                 .HasMaxLength(20);
        }
    }
}
