using System;
using System.Runtime.CompilerServices;
using PixelWorld.DAL.Entity;

[assembly: InternalsVisibleTo("PixelWorld.BLL.Tests")]
namespace PixelWorld.Infrastructure.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        public void Save();
    }
}
