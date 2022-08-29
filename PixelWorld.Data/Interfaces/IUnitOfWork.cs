using PixelWorld.Data.Entity;
using System;

namespace PixelWorld.Data.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        public IRepository<User> Users { get; }
        public IRepository<Item> Items { get; }
        public IRepository<Order> Orders { get; }
        public void Save();
    }
}
