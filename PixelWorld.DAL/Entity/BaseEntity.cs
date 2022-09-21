using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PixelWorld.Infrastructure")]
[assembly: InternalsVisibleTo("PixelWorld.BLL")]
namespace PixelWorld.DAL.Entity
{
    internal abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
