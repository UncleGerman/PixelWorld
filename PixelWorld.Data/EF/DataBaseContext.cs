using PixelWorld.Data.Entity;
using System.Data.Entity;

namespace PixelWorld.Data.EF
{
    internal sealed class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public  DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        internal DataBaseContext (string conectionString) : base (conectionString)
        {
            if (string.IsNullOrEmpty(conectionString))
            {
                throw new System.ArgumentNullException(nameof(conectionString));
            }
        }

        internal void RemoveDataBase()
        {
            Database.Delete();
            Database.Create();
        }
    }
}
