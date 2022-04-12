using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class SeedData
    {
        public static async Task SeedAsync(ApplicationContext applicationContext, ILogger<SeedData> logger)
        {
            if (!applicationContext.Orders.Any())
            {
                await applicationContext.Orders.AddRangeAsync(GetPreconfiguredOrders());
                await applicationContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}",typeof(ApplicationContext).Name);
            }
        }
        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {
                    UserName = "Abdul.naveed",
                    FirstName = "Abdul",
                    LastName = "Naveed",
                    EmailAddress = "abdul.naveed@mparsec.com",
                    AddressLine = "Islamabad",
                    Country = "Islamabad",
                    TotaPrice = 340
                }
            };
        }
    }
}
