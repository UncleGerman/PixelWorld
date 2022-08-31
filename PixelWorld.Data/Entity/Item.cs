namespace PixelWorld.Data.Entity
{
    internal sealed class Item
    {
        internal int Id { get; set; }
        internal int Quantity { get; set; }
        internal string Name { get; set; }
        internal ItemType ItemType { get; set; }
    }
}
