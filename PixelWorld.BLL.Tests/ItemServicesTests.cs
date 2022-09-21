using PixelWorld.BLL.DTO;
using PixelWorld.BLL.Services;
using PixelWorld.Infrastructure;
using System;
using Xunit;

namespace PixelWorld.BLL.Tests
{
    public sealed class ItemServicesTests
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ItemServices _itemServices;
        private ItemDTO _itemDTO;

        public ItemServicesTests()
        {
            _unitOfWork = new UnitOfWork(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = PixelWorldDataBase; Integrated Security = SSPI;");
            _unitOfWork.RemoveDb();
            _itemServices = new ItemServices(_unitOfWork);
            _itemDTO.Id = 1;
            _itemDTO.Name = "Item";
            //_itemDTO.ItemType = ItemType.Potion;
        }

        [Fact]
        public void CreateValid()
        {
            _itemServices.Create(_itemDTO);
            var item = _itemServices.GetById(_itemDTO.Id);
            Assert.Equal(_itemDTO, item);
        }

        [Fact]
        public void UpdateIsValid()
        {
            _itemServices.Create(_itemDTO);
            _itemServices.Update(_itemDTO);
            var item = _itemServices.GetById(_itemDTO.Id);
            Assert.Equal(_itemDTO, item);
        }

        [Fact]
        public void UpdateEmptyValue()
        {
            _itemDTO.Id = 2;
            var exception = Assert.Throws<ArgumentNullException>(() => _itemServices.Update(_itemDTO));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void UpdateOutOfRange(int id)
        {
            _itemDTO.Id = id;
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _itemServices.Update(_itemDTO));
        }

        [Fact]
        public void DeleteIsValid()
        {
            _itemServices.Create(_itemDTO);
            _itemServices.Delete(_itemDTO.Id);
            Assert.Throws<ArgumentNullException>(() => _itemServices.GetById(_itemDTO.Id));
        }

        [Fact]
        public void DeleteEmptyValue()
        {
            var id = 2;
            Assert.Throws<ArgumentNullException>(() => _itemServices.Delete(id));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void DeleteOutOfRange(int id)
        {
            _itemDTO.Id = id;
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _itemServices.Delete(id));
        }
    }
}
