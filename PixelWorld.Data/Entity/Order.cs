using System;

namespace PixelWorld.Data.Entity
{
    internal sealed class Order
    {
        internal int Id { get; set; }
        internal decimal Price { get; set; }
        internal User User { get; set; }
        internal Item Item { get; set; }
        internal DateTime PublicationTime { get; set; }
        internal DateTime PublicationEndTime { get; set; }
    }
}
