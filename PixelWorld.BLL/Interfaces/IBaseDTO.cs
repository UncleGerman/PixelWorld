using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PixelWorld.BLL.Tests")]
namespace PixelWorld.BLL.Interfaces
{
    internal interface IBaseDTO
    {
        public int Id { get; set; }
    }
}
