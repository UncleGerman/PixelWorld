using PixelWorld.Data.EF;
using PixelWorld.Data.Repositories;
using System;
using Xunit;

namespace PixelWorld.Data.Tests
{
    public class DataBase
    {
        internal static string ConectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = ContosoUniversity1; Integrated Security = SSPI;";

        [Fact]
        public void DataBaseContextIsValid() => new DataBaseContext(ConectionString);

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DataBaseContextEmptyOrNullConectionPath(string conectionString)
        {
            var exeption = Assert.Throws<ArgumentException>(() => new DataBaseContext(conectionString));
            Assert.Equal(nameof(conectionString), exeption.ParamName);
        }

        [Fact]
        public void EFUnitOfWorkIsValid() => new EFUnitOfWork(ConectionString);

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EFUnitOfWorkEmptyOrNullConectionPath(string conectionString)
        {
            var exeption = Assert.Throws<ArgumentNullException>(() => new EFUnitOfWork(conectionString));
            Assert.Equal(nameof(conectionString), exeption.ParamName);
        }
    }
}
