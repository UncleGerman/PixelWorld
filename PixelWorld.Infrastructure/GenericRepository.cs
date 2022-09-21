using System.Data.Entity;
using System.Collections.Generic;
using PixelWorld.Infrastructure.EF;
using PixelWorld.Infrastructure.Interfaces;
using PixelWorld.DAL.Entity;

namespace PixelWorld.Infrastructure.GenericRepository
{
    internal sealed class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly DbSet _entityContext;

        internal GenericRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext ?? throw new System.ArgumentNullException(nameof(dataBaseContext));
            _entityContext = _dataBaseContext.Set<TEntity>();
        }

        public void Create(TEntity entity) => _entityContext.Add(entity);

        public void Update(TEntity item)
        {
            _dataBaseContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entityToDelete = _entityContext.Find(id);
            _entityContext.Remove(entityToDelete);
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            return (IReadOnlyCollection<TEntity>)_entityContext;
        }

        public TEntity GetById(int id)
        {
            var entity = _entityContext.Find(id);

            return (TEntity)entity;
        }
    }
}
