using System.Collections.Generic;

namespace PixelWorld.Data.Entity
{
    public sealed class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<Item> Inventory { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
