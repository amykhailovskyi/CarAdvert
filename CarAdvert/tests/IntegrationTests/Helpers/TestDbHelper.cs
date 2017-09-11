using CA.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IntegrationTests.Helpers
{
    public static class TestDbHelper
    {
        public static AppDbContext GetInMemoryDbContext(string dbName)
        {
            return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options);
        }
    }
}
