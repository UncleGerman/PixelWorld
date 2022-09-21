using PixelWorld.DAL.Entity.Identity;
using System;

namespace PixelWorld.DAL.Entity
{
    internal sealed class Order : BaseEntity
    {
        internal decimal Price { get; set; }

        internal int UserId { get; set; }

        internal ApplicationUser User { get; set; }

        internal int ItemId { get; set; }

        internal Item Item { get; set; }

        internal DateTime PublicationTime { get; set; }

        internal DateTime PublicationEndTime { get; set; }
    }
}
