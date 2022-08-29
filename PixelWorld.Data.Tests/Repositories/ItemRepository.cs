using PixelWorld.Data.Entity;
using PixelWorld.Data.Repositories;
using PixelWorld.Data.Tests.Interfaces;
using System;
using Xunit;

namespace PixelWorld.Data.Tests.Repositories
{
    public sealed class ItemRepository : IRepositoryTests
    {
        private Item _item = new Item()
        {
            Id = 1,
            Quantity = 2,
            Name = "New Item",
            ItemType = ItemType.Potion
        };

        private readonly EFUnitOfWork _eFUnitOfWork;

        public ItemRepository()
        {
            _eFUnitOfWork = new EFUnitOfWork(DataBase.ConectionString);
            _eFUnitOfWork.CreateTestDataBase();
        }

        [Fact]
        public void CreateIsValid()
        {
            _eFUnitOfWork.Items.Create(_item);
            var item = _eFUnitOfWork.Items.Get(_item.Id);

            Assert.Equal(item, _item);
        }

        [Fact]
        public void CreateNullValue()
        {
            Item item = null;
            var exeption = Assert.Throws<ArgumentNullException>(() => _eFUnitOfWork.Items.Create(item));
            Assert.Equal(nameof(item), exeption.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateOutOfRange(int id)
        {
            _item.Id = id;
            var item = _item;
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Items.Create(item));
            Assert.Equal(nameof(item.Id), exeption.ParamName);
        }

        [Fact]
        public void RemoveIsValid()
        {
            _eFUnitOfWork.Items.Create(_item);
            _eFUnitOfWork.Save();

            _eFUnitOfWork.Items.Remove(_item.Id);
            _eFUnitOfWork.Save();

            var isItem = _eFUnitOfWork.Items.Get(_item.Id) == null;

            Assert.True(isItem);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        public void RemoveOutOfRange(int id)
        {
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Items.Remove(id));
            Assert.Equal(nameof(id), exeption.ParamName);
        }

        [Fact]
        public void UpdateIsValid()
        {
            var newQuantity = 5;

            _eFUnitOfWork.Items.Create(_item);
            _eFUnitOfWork.Save();

            var item = _eFUnitOfWork.Items.Get(_item.Id);
            item.Quantity = newQuantity;

            _eFUnitOfWork.Items.Update(item);
            _eFUnitOfWork.Save();

            item = _eFUnitOfWork.Items.Get(_item.Id);

            Assert.Equal(item.Quantity, newQuantity);
        }

        [Fact]
        public void UpdateNullValue()
        {
            Item item = null;
            var exeption = Assert.Throws<ArgumentNullException>(() => _eFUnitOfWork.Items.Update(item));
            Assert.Equal(nameof(item), exeption.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(2)]
        public void UpdateOutOfRange(int id)
        {
            _item.Id = id;
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => _eFUnitOfWork.Items.Update(_item));
            Assert.Equal(nameof(_item.Id), exeption.ParamName);
        }
    }
}
