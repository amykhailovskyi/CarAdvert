using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace CA.Data.Db
{
    /// <summary>
    /// This will be used only to execute migrations (dotnet ef database update) in develpment or production environments.
    /// Used from CMD it will load the connection string from the appsettings.json file.
    /// </summary>
    public class AppDbContextFactory : IDbContextFactory<AppDbContext>
    {
        public AppDbContext Create(DbContextFactoryOptions options)
        {
            string basePath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false);
            //.AddEnvironmentVariables();

            var config = builder.Build();

            string connstr = config.GetConnectionString("CarAdvertConnection");

            if (String.IsNullOrWhiteSpace(connstr))
            {
                throw new InvalidOperationException(
                    "Could not find a connection string named 'CarAdvertConnection'.");
            }
            return Create(connstr);
        }
        private AppDbContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                    $"{nameof(connectionString)} is null or empty.",
                    nameof(connectionString));

            var optionsBuilder =
                new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
