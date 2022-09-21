using System.Collections.Generic;

namespace PixelWorld.DAL.Entity.Identity
{
    internal sealed class UserProfile : BaseEntity
    {
        internal string Name { get; set; }

        internal string Email { get; set; }

        internal ICollection<Item> Inventory { get; set; }

        internal ICollection<Order> Orders { get; set; }

        internal ApplicationUser ApplicationUser { get; set; }
    }
}
