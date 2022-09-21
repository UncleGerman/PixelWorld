using Microsoft.AspNet.Identity.EntityFramework;

namespace PixelWorld.DAL.Entity.Identity
{
    internal class ApplicationUser : IdentityUser
    {
        internal virtual UserProfile UserProfile { get; set; }
    }
}
