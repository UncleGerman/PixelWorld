using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PixelWorld.BLL.DTO;
using PixelWorld.BLL.Interfaces;
using PixelWorld.DAL.Entity;
using PixelWorld.DAL.Interfaces;
using PixelWorld.Infrastructure;

[assembly: InternalsVisibleTo("PixelWorld.Infrastructure.Tests")]
namespace PixelWorld.BLL.Services
{
    internal sealed class ItemServices : IService<ItemDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Item> _genericRepository;

        internal ItemServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _genericRepository = _unitOfWork.GetRepository<Item>();
        }

        public void Create(ItemDTO entityDTO)
        {
            var item = new Item()
            {
                Id = entityDTO.Id,
                Name = entityDTO.Name,
                ItemType = entityDTO.ItemType
            };

            _genericRepository.Create(item);
        }

        public void Delete(int entityId)
        {
            if (entityId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityId));
            }
            else
            {
                var item = _genericRepository.GetById(entityId);

                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
                else
                {
                    _genericRepository.Delete(entityId);
                }
            }
        }

        public void Dispose() => _unitOfWork.Dispose();

        public IReadOnlyCollection<ItemDTO> GetAll()
        {
            return (IReadOnlyCollection<ItemDTO>)_genericRepository.GetAll();
        }

        public ItemDTO GetById(int entityId)
        {
            if (entityId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityId));
            }
            else
            {
                var item = _genericRepository.GetById(entityId);

                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
                else
                {
                    return (ItemDTO)item;
                }
            }
        }

        public void Update(ItemDTO entityDTO)
        {
            if (entityDTO.Id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityDTO.Id));
            }
            else
            {
                var item = _genericRepository.GetById(entityDTO.Id);

                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
                else
                {
                    var itemDTO = new Item()
                    {
                        Id = entityDTO.Id,
                        Name = entityDTO.Name,
                        ItemType = entityDTO.ItemType
                    };

                    _genericRepository.Update(itemDTO);
                }
            }
        }
    }
}
