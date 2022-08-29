using PixelWorld.Data.Entity;
using PixelWorld.Data.Repositories;
using PixelWorld.Data.Tests.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace PixelWorld.Data.Tests.Repositories
{
    public sealed class UserRepository : IRepositoryTests
    {
        private User _user = new User()
        {
            Id = 1,
            Name = "Bob",
            Password = "y01nw2",
            Email = "Test@gmail.com",

            Inventory = new List<Item> {
                new Item()
                {
                    Id = 1,
                    Quantity = 2,
                    Name = "New Item",
                    ItemType = ItemType.Potion
                }
            },

            Orders = new List<Order>
            {
                new Order()
                {
                    Id = 1,
                    Price = 2,
                    Item = new Item()
                    {
                        Id = 1,
                        Quantity = 2,
                        Name = "New Item",
                        ItemType = ItemType.Potion
                    },

                    PublicationTime = new DateTime(),
                    PublicationEndTime = new DateTime()
                }
            }
        };

        private readonly EFUnitOfWork _eFUnitOfWork;

        public UserRepository()
        {
            _eFUnitOfWork = new EFUnitOfWork(DataBase.ConectionString);
            _eFUnitOfWork.CreateTestDataBase();
        }

        [Fact]
        public void CreateIsValid()
        {
            _eFUnitOfWork.Users.Create(_user);
            var user = _eFUnitOfWork.Users.Get(_user.Id);

            Assert.Equal(user, _user);
        }

        [Fact]
        public void CreateNullValue()
        {
            User item = null;
            var exeption = Assert.Throws<ArgumentNullException>(() => _eFUnitOfWork.Users.Create(item));
            Assert.Equal(nameof(item), exeption.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateOutOfRange(int id)
        {
            var item = _user;
            item.Id = id;
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Users.Create(item));
            Assert.Equal(nameof(item.Id), exeption.ParamName);
        }

        [Fact]
        public void RemoveIsValid()
        {
            _eFUnitOfWork.Users.Create(_user);
            _eFUnitOfWork.Save();

            _eFUnitOfWork.Users.Remove(_user.Id);
            _eFUnitOfWork.Save();

            var isUser = _eFUnitOfWork.Users.Get(_user.Id) == null;

            Assert.True(isUser);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(100)]
        public void RemoveOutOfRange(int id)
        {
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Users.Remove(id));
            Assert.Equal(nameof(id), exeption.ParamName);
        }

        [Fact]
        public void UpdateIsValid()
        {
            var newName = "Jon";

            _eFUnitOfWork.Users.Create(_user);
            _eFUnitOfWork.Save();

            var user = _eFUnitOfWork.Users.Get(_user.Id);
            user.Name = newName;

            _eFUnitOfWork.Users.Update(user);
            _eFUnitOfWork.Save();

            user = _eFUnitOfWork.Users.Get(_user.Id);

            Assert.Equal(user.Name, newName);
        }

        [Fact]
        public void UpdateNullValue()
        {
            User item = null;
            var exeption = Assert.Throws<ArgumentNullException>(() => _eFUnitOfWork.Users.Update(item));
            Assert.Equal(nameof(item), exeption.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(100)]
        public void UpdateOutOfRange(int id)
        {
            var item = _user;
            item.Id = id;
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Users.Update(item));
            Assert.Equal(nameof(item.Id), exeption.ParamName);
        }
    }
}
