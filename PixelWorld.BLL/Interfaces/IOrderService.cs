using PixelWorld.BLL.DTO;

namespace PixelWorld.BLL.Interfaces
{
    internal interface IOrderService
    {
        public ItemDTO GetItem(int orderId);
    }
}
