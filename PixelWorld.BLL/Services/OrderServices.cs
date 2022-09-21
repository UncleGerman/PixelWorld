using System;
using System.Collections.Generic;
using PixelWorld.BLL.DTO;
using PixelWorld.BLL.Interfaces;
using PixelWorld.DAL.Entity;
using PixelWorld.DAL.Interfaces;

namespace PixelWorld.BLL.Services
{
    internal sealed class OrderServices : IService<OrderDTO>, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Order> _genericRepository;

        internal OrderServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _genericRepository = _unitOfWork.GetRepository<Order>();
        }

        public void Create(OrderDTO entityDTO)
        {
            var order = new Order()
            {
                Id = entityDTO.Id,
                PublicationEndTime = entityDTO.PublicationEndTime,
                PublicationTime = entityDTO.PublicationTime
            };
        }

        public void Delete(int entityId)
        {
            if (entityId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityId));
            }
            else
            {
                _genericRepository.Delete(entityId);
            }
        }

        public void Dispose() => _unitOfWork.Dispose();

        public IReadOnlyCollection<OrderDTO> GetAll()
        {
            return (IReadOnlyCollection<OrderDTO>)_genericRepository.GetAll();
        }

        public OrderDTO GetById(int entityId)
        {
            if (entityId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityId));
            }
            else
            {
                var order = _genericRepository.GetById(entityId);

                if (order == null)
                {
                    throw new ArgumentNullException(nameof(order));
                }
                else
                {
                    return (OrderDTO)order;
                }
            }
        }

        public ItemDTO GetItem(int orderId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }
            else
            {
                var order = _genericRepository.GetById(orderId);

                if (order == null)
                {
                    throw new ArgumentNullException(nameof(order));
                }
                else
                {
                    return (ItemDTO)order.Item;
                }
            }
        }

        public void Update(OrderDTO entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
