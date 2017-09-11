using System;
using CA.Business.Services;
using CA.Data.Entities;
using CA.Data.Repositories;
using Xunit;
using System.Threading.Tasks;
using CA.Business.DTOs;

namespace IntegrationTests.Business
{
    [Trait("Category", "Integration")]
    public class CarAdvertServiceTest
    {
        private static readonly string DbName = $"db_in_mem_{Guid.NewGuid()}";
        private readonly CarAdvertService _advertService;

        public CarAdvertServiceTest()
        {
            var repository = new Repository<CarAdvert>(Helpers.TestDbHelper.GetInMemoryDbContext(DbName));
            _advertService = new CarAdvertService(repository);
        }

        [Fact]
        public async Task CreateNewCarAdvertShouldBeSuccess()
        {
            var expected = GetCarAdvertDto();

            var id = await _advertService.Add(expected);
            var obj = await _advertService.GetById(id);

            Assert.NotNull(obj);
            AssertEquals(expected, obj);
        }

        [Fact]
        public async Task CreateUsedCarAdvertShouldBeThrowException()
        {
            var expected = GetCarAdvertDto();
            expected.New = false;

            await Assert.ThrowsAsync<ArgumentException>(() => _advertService.Add(expected));
        }

        private void AssertEquals(CarAdvertDto expected, CarAdvertDto obj)
        {
            Assert.Equal(expected.Price, obj.Price);
            Assert.Equal(expected.Mileage, obj.Mileage);
            Assert.Equal(expected.Title, obj.Title);
            Assert.Equal(expected.FuelTypeId, obj.FuelTypeId);
            Assert.Equal(expected.New, obj.New);
            Assert.Equal(expected.FirstRegistration, obj.FirstRegistration);
        }

        private CarAdvertDto GetCarAdvertDto()
        {
            return new CarAdvertDto
            {
                New = true,
                Price = 12345,
                Title = "Test car 1",
                FuelTypeId = 1
            };
        }
    }
}
