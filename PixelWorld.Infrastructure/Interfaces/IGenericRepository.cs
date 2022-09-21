using System.Collections.Generic;
using PixelWorld.DAL.Entity;

namespace PixelWorld.Infrastructure.Interfaces
{
    internal interface IGenericRepository<TEntity> where TEntity : BaseEntity
    { 
        public void Create(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(int id);

        public IReadOnlyCollection<TEntity> GetAll();

        public TEntity GetById(int id);
    }
}
