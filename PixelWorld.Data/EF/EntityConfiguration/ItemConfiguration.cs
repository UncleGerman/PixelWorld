using PixelWorld.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PixelWorld.Data.EF.EntityConfiguration
{
    internal sealed class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        internal ItemConfiguration()
        {
            EntityTypeConfiguration<Item> tableName = ToTable(tableName: nameof(Item));

            tableName.HasKey(c => c.Id);

            tableName.Property(c => c.Quantity).IsRequired();
            tableName.Property(c => c.ItemType).IsRequired();

            tableName.Property(c => c.Name)
                                 .IsRequired()
                                 .HasMaxLength(20);
        }
    }
}
