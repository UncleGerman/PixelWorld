using PixelWorld.Infrastructure.Identity;
using System.Threading.Tasks;

namespace PixelWorld.Infrastructure.Interfaces
{
    internal interface IIdentityUnitOfWork : IUnitOfWork
    {
        public ApplicationUserManager UserManager { get; }

        public ApplicationRoleManager RoleManager { get; }

        public Task SaveAsync();
    }
}
