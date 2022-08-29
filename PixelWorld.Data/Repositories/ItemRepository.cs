using PixelWorld.Data.EF;
using PixelWorld.Data.Entity;
using PixelWorld.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PixelWorld.Data.Repositories
{
    internal sealed class ItemRepository : IRepository<Item>
    {
        private readonly DataBaseContext _dataBaseContext;

        internal ItemRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext ?? throw new ArgumentNullException(nameof(dataBaseContext));
        }

        public void Create(Item item)
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
                    _dataBaseContext.Items.Add(item);
                }
            }
        }

        public IEnumerable<Item> Find(Func<Item, bool> predicate) => _dataBaseContext.Items.Include(o => o.Id).Where(predicate).ToList();

        public Item Get(int id) => _dataBaseContext.Items.Find(id);

        public IEnumerable<Item> GetAll() => _dataBaseContext.Items;

        public void Remove(int id)
        {
            if (id > _dataBaseContext.Items.Count() ^ id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                var foundItem = _dataBaseContext.Items.Find(id);

                _dataBaseContext.Items.Remove(foundItem);
            }
        }

        public void Update(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (item.Id > _dataBaseContext.Items.Count() ^ item.Id <= 0)
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
