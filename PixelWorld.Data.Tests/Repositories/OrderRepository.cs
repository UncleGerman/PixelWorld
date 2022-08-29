using PixelWorld.Data.Entity;
using PixelWorld.Data.Repositories;
using PixelWorld.Data.Tests.Interfaces;
using System;
using Xunit;

namespace PixelWorld.Data.Tests.Repositories
{
    public sealed class OrderRepository : IRepositoryTests
    {
        private Order _order = new Order()
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
            PublicationTime = new DateTime().ToLocalTime(),
            PublicationEndTime = new DateTime().ToLocalTime()
        };

        private readonly EFUnitOfWork _eFUnitOfWork;

        public OrderRepository()
        {
            _eFUnitOfWork = new EFUnitOfWork(DataBase.ConectionString);
            _eFUnitOfWork.CreateTestDataBase();
        }

        [Fact]
        public void CreateIsValid()
        {
            _eFUnitOfWork.Orders.Create(_order);
            var order = _eFUnitOfWork.Orders.Get(_order.Id);

            Assert.Equal(order, _order);
        }

        [Fact]
        public void CreateNullValue()
        {
            Order item = null;
            var exeption = Assert.Throws<ArgumentNullException>(()=> _eFUnitOfWork.Orders.Create(item));
            Assert.Equal(nameof(item), exeption.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateOutOfRange(int id)
        {
            _order.Id = id;
            var item = _order;
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Orders.Create(item));
            Assert.Equal(nameof(item.Id), exeption.ParamName);
        }

        [Fact]
        public void RemoveIsValid()
        {
            _eFUnitOfWork.Orders.Create(_order);
            _eFUnitOfWork.Save();

            _eFUnitOfWork.Orders.Remove(_order.Id);
            _eFUnitOfWork.Save();

            var isOrder = _eFUnitOfWork.Orders.Get(_order.Id) == null;

            Assert.True(isOrder);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        public void RemoveOutOfRange(int id)
        {
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Orders.Remove(id));
            Assert.Equal(nameof(id), exeption.ParamName);
        }

        [Fact]
        public void UpdateIsValid()
        {
            var newPrice = 5;

            _eFUnitOfWork.Orders.Create(_order);
            _eFUnitOfWork.Save();

            var order = _eFUnitOfWork.Orders.Get(_order.Id);
            order.Price = newPrice;

            _eFUnitOfWork.Orders.Update(order);
            _eFUnitOfWork.Save();

            order = _eFUnitOfWork.Orders.Get(_order.Id);

            Assert.Equal(order.Price, newPrice);
        }

        [Fact]
        public void UpdateNullValue()
        {
            Order item = null;
            var exeption = Assert.Throws<ArgumentNullException>(() => _eFUnitOfWork.Orders.Update(item));
            Assert.Equal(nameof(item), exeption.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        public void UpdateOutOfRange(int id)
        {
            _order.Id = id;
            var item = _order;
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Orders.Update(item));
            Assert.Equal(nameof(item.Id), exeption.ParamName);
        }
    }
}
