using PixelWorld.Data.EF;
using PixelWorld.Data.Entity;
using PixelWorld.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PixelWorld.Data.Repositories
{
    internal sealed class UserRepository : IRepository<User>
    {
        private readonly DataBaseContext _dataBaseContext;

        internal UserRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext ?? throw new ArgumentNullException(nameof(dataBaseContext));
        }

        public void Create(User item)
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
                    _dataBaseContext.Users.Add(item);
                }
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate) => _dataBaseContext.Users.Include(o => o.Id).Where(predicate).ToList();

        public User Get(int id) => _dataBaseContext.Users.Find(id);

        public IEnumerable<User> GetAll() => _dataBaseContext.Users;

        public void Remove(int id)
        {
            if (id > _dataBaseContext.Users.Count() ^ id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                var item = _dataBaseContext.Users.Find(id);
                _dataBaseContext.Users.Remove(item);
            }
        }

        public void Update(User item)
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