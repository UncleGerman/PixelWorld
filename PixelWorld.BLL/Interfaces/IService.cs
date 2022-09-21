using System.Collections.Generic;

namespace PixelWorld.BLL.Interfaces
{
    internal interface IService<TEntityDTO> where TEntityDTO : IBaseDTO
    {
        public void Create(TEntityDTO entityDTO);

        public void Update(TEntityDTO entityDTO);

        public void Delete(int entityId);

        public void Dispose();

        public TEntityDTO GetById(int entityId);

        public IReadOnlyCollection<TEntityDTO> GetAll();
    }
}
