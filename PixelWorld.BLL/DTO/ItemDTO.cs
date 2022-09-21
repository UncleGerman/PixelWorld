using PixelWorld.BLL.Interfaces;
using PixelWorld.DAL.Entity;

namespace PixelWorld.BLL.DTO
{
    internal struct ItemDTO : IBaseDTO
    {
        public static explicit operator ItemDTO(Item item)
        {
            var itemDTO = new ItemDTO()
            {
                Id = item.Id,
                ItemType = item.ItemType,
                Name = item.Name
            };

            return itemDTO;
        }

        public int Id { get; set; }

        internal string Name
        {
            get => _name;
            set => _name = value == "" ? "New Item" : value;
        }

        internal ItemType ItemType { get; set; }

        private string _name;
    }
}
