using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Data.Db;
using CA.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Api.Configurations
{
    public static class DataSeeder
    {
        /// <summary>
        /// This is a workaround for missing seed data functionality in EF 7.0-rc1
        /// More info: https://github.com/aspnet/EntityFramework/issues/629
        /// </summary>
        /// <param name="app">
        /// An instance that provides the mechanisms to get instance of the database context.
        /// </param>
        public static void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<AppDbContext>();
            if (db.FuelTypes.Any())
                return;

            db.FuelTypes.AddRange(new List<FuelType>
            {
                new FuelType {Name = "Gasoline"},
                new FuelType {Name = "Diesel"}
            });

            db.SaveChanges();
        }
    }
}
