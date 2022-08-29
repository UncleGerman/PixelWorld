using PixelWorld.Data.EF;
using PixelWorld.Data.Entity;
using PixelWorld.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PixelWorld.Data.Repositories
{
    internal sealed class OrderRepository : IRepository<Order>
    {
        private readonly DataBaseContext _dataBaseContext;

        internal OrderRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext ?? throw new ArgumentNullException(nameof(dataBaseContext));
        }

        public void Create(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (item.Id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(item.Id));
                }
                else
                {
                    _dataBaseContext.Orders.Add(item);
                }
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate) => _dataBaseContext.Orders.Include(o => o.Id).Where(predicate).ToList();

        public Order Get(int id) => _dataBaseContext.Orders.Find(id);

        public IEnumerable<Order> GetAll() => _dataBaseContext.Orders;

        public void Remove(int id)
        {
            if (id > _dataBaseContext.Orders.Count() ^ id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                var foundItem = _dataBaseContext.Orders.Find(id);
                _dataBaseContext.Orders.Remove(foundItem);
            }
        }

        public void Update(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (item.Id > _dataBaseContext.Orders.Count() ^ item.Id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(item.Id));
                }
                else
                {
                    _dataBaseContext.Entry(item).State = EntityState.Modified;
                }
            }
        }
    }
}
