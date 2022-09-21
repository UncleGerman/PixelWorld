using Microsoft.AspNet.Identity;
using PixelWorld.DAL.Entity.Identity;

namespace PixelWorld.Infrastructure.Identity
{
    internal sealed class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store) { }
    }
}
