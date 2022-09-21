using PixelWorld.BLL.Interfaces;
using PixelWorld.DAL.Entity;
using System;

namespace PixelWorld.BLL.DTO
{
    internal struct OrderDTO : IBaseDTO
    {
        public int Id { get; set; }

        internal decimal Price
        {
            get => _price;
            set => _price = value <= 0 ? 5 : value;
        }

        internal int ItemId { get; set; }

        internal int UserId { get; set; }

        internal DateTime PublicationTime
        {
            get => _publicationTime;
            set => _publicationTime = value < DateTime.Now ? DateTime.Now : value;
        }

        internal DateTime PublicationEndTime
        {
            get => _publicationEndTime;
            set => _publicationEndTime = value < DateTime.Now ? DateTime.Now : value;
        }

        public static explicit operator OrderDTO(Order order)
        {
            var orderDTO = new OrderDTO()
            {
                ItemId = order.ItemId,
                UserId = order.UserId,
                Price = order.Price,
                PublicationTime = order.PublicationTime,
                PublicationEndTime = order.PublicationEndTime
            };

            return orderDTO;
        }

        private decimal _price;

        private DateTime _publicationTime;

        private DateTime _publicationEndTime;
    }
}
