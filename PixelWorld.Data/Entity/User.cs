using System.Collections.Generic;

namespace PixelWorld.Data.Entity
{
    internal sealed class User
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Password { get; set; }
        internal string Email { get; set; }
        internal ICollection<Item> Inventory { get; set; }
        internal ICollection<Order> Orders { get; set; }
    }
}
