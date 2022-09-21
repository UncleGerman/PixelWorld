using System;

namespace PixelWorld.DAL.Entity
{
    internal sealed class Item : BaseEntity
    {
        internal string Name { get; set; }

        internal ItemType ItemType { get; set; }
    }
}
