using PixelWorld.Data.Entity;

namespace PixelWorld.Data.Tests.Interfaces
{
    internal interface IRepositoryTests
    {
        public void CreateIsValid();
        public void CreateNullValue();
        public void CreateOutOfRange(int id);
        public void RemoveIsValid();
        public void RemoveOutOfRange(int id);
        public void UpdateIsValid();
        public void UpdateNullValue();
        public void UpdateOutOfRange(int id);
    }
}
