using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PixelWorld.DAL.Entity.Identity;

namespace PixelWorld.Infrastructure.Identity
{
    internal sealed class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store) 
            : base(store) { }
    }
}
