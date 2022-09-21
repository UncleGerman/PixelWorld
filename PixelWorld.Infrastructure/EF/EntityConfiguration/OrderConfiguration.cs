using PixelWorld.DAL.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PixelWorld.Infrastructure.EF.EntityConfiguration
{
    internal sealed class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        private const string _dataTypeValue = "datetime2";
        internal OrderConfiguration()
        {
            EntityTypeConfiguration<Order> tableName = ToTable(tableName: nameof(Order));

            tableName.HasKey(o => o.Id);
            tableName.Property(o => o.Price).IsRequired();

            tableName.Property(o => o.PublicationTime)
                     .HasColumnType(_dataTypeValue)
                     .HasPrecision(0);

            tableName.Property(o => o.PublicationEndTime)
                     .HasColumnType(_dataTypeValue)
                     .HasPrecision(0);
        }
    }
}
