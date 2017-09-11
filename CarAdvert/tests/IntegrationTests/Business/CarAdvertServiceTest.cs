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
        public async Task Test1()
        {
            var expected = GetCarAdvertDto();

            var id = await _advertService.Add(expected);
            var obj = await _advertService.GetById(id);

            Assert.NotNull(obj);
            Assert.Equal(expected.Price, obj.Price);
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
