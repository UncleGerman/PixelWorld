using PixelWorld.BLL.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PixelWorld.BLL.Interfaces
{
    internal interface IUserService
    {
        Task Create(UserDTO userDto);

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);

        Task SetInitialData(UserDTO adminDto, List<string> roles);

        public IReadOnlyCollection<OrderDTO> GetOrders(int userId);

        public IReadOnlyCollection<ItemDTO> GetInventory(int userId);

        public void AddItem(int userId, int itemId);
    }
}
