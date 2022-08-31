using PixelWorld.Data.EF;
using PixelWorld.Data.Entity;
using PixelWorld.Data.Interfaces;
using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("PixelWorld.Data.Tests")]
[assembly: InternalsVisibleTo("PixelWorld.Infrastructure")]
[assembly: InternalsVisibleTo("PixelWorld.Infrastructure.Tests")]
namespace PixelWorld.Data.Repositories
{
    internal sealed class EFUnitOfWork : IUnitOfWork
    {
        private DataBaseContext _dataBaseContext;

        private UserRepository _userRepository;
        private ItemRepository _itemRepository;
        private OrderRepository _orderRepository;

        private const string _conectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = PixelWorldDataBase; Integrated Security = SSPI;";

        private bool disposedValue;

        internal EFUnitOfWork(string conectionString)
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

        internal void CreateTestDataBase()
        {
            _dataBaseContext = new DataBaseContext(_conectionString);
            _dataBaseContext.RemoveDataBase();
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dataBaseContext);

                    return _userRepository;
                }
                else
                {
                    return _userRepository;
                }
            }
        }

        public IRepository<Item> Items
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository(_dataBaseContext);

                    return _itemRepository;
                }
                else
                {
                    return _itemRepository;
                }
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_dataBaseContext);

                    return _orderRepository;
                }
                else
                {
                    return _orderRepository;
                }
            }
        }

        public void Save() => _dataBaseContext.SaveChanges();

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~EFUnitOfWork()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
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
    }
}
