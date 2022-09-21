using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PixelWorld.BLL.DTO;
using PixelWorld.BLL.Interfaces;
using PixelWorld.DAL.Interfaces;
using PixelWorld.DAL.Entity.Identity;
using System.Security.Claims;

namespace PixelWorld.Infrastructure.Services
{
    internal sealed class UserServices : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserProfile> _genericRepository;

        internal UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _genericRepository = _unitOfWork.GetRepository<UserProfile>();
        }

        public void AddItem(int userId, int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public Task Create(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<ItemDTO> GetInventory(int userId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<OrderDTO> GetOrders(int userId)
        {
            throw new NotImplementedException();
        }

        public Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}
