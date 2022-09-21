using PixelWorld.BLL.Interfaces;
using PixelWorld.DAL.Entity;
using PixelWorld.DAL.Entity.Identity;
using System.Collections.Generic;

namespace PixelWorld.BLL.DTO
{
    internal struct UserDTO : IBaseDTO
    {
        public int Id { get; set; }

        internal string Name { get; set; }

        internal string Email { get; set; }

        internal string Password { get; set; }

        internal string Role { get; set; }

        internal ICollection<Item> Inventory { get; set; }

        internal ICollection<Order> Orders { get; set; }

        public static explicit operator UserDTO(UserProfile user)
        {
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Inventory = user.Inventory,
                Orders = user.Orders
            };

            return userDTO;
        }
    }
}
