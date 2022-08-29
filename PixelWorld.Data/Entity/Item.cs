namespace PixelWorld.Data.Entity
{
    public sealed class Item
    {
        public int Id { get; set; }
        public int Quantity 
        {
            get => _quantity;
            set
            {
                if (value < 1)
                {
                    _quantity = 1;
                }
                else
                {
                    _quantity = value;
                }
            }
        }

        public string Name 
        { 
            get => _name; 
            set
            {
                if (value.Length == 0)
                {
                    _name = "New Item";
                }
                else
                {
                    _name = value;
                }
            }
        }

        public ItemType ItemType { get; set; }

        private int _quantity;
        private string _name;
    }
}
