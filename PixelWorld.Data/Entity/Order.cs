using System;

namespace PixelWorld.Data.Entity
{
    public sealed class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public Item Item { get; set; }
        public DateTime PublicationTime { get; set; }
        public DateTime PublicationEndTime { get; set; }
    }
}
