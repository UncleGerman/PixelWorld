using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.AspNet.Identity.EntityFramework;
using PixelWorld.DAL.Entity;
using PixelWorld.Infrastructure.GenericRepository;
using PixelWorld.Infrastructure.Identity;
using PixelWorld.Infrastructure.EF;
using PixelWorld.DAL.Entity.Identity;
using PixelWorld.Infrastructure.Interfaces;

[assembly: InternalsVisibleTo("PixelWorld.BLL")]
[assembly: InternalsVisibleTo("PixelWorld.BLL.Tests")]
namespace PixelWorld.Infrastructure
{
    internal sealed class UnitOfWork : IUnitOfWork, IIdentityUnitOfWork
    {
        private readonly DataBaseContext _dataBaseContext;

        private bool disposedValue;

        internal UnitOfWork(string conectionString)
        {
            if (string.IsNullOrEmpty(conectionString))
            {
                throw new ArgumentNullException(nameof(conectionString));
            }
            else
            {
                _dataBaseContext = new DataBaseContext(conectionString);
            }
        }

        internal void RemoveDb()
        {
            _dataBaseContext.RemoveDataBase();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                var userStore = new UserStore<ApplicationUser>(_dataBaseContext);
                var applicationUserManager = new ApplicationUserManager(userStore);

                return applicationUserManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                var roleStore = new RoleStore<ApplicationRole>(_dataBaseContext);
                var applicationRoleManager = new ApplicationRoleManager(roleStore);

                return applicationRoleManager;
            }
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return new GenericRepository<TEntity>(_dataBaseContext);
        }

        public void Save() => _dataBaseContext.SaveChanges();

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
