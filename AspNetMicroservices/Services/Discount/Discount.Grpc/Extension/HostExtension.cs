using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;

namespace Discount.Grpc.Extension
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();
                try
                {
                    logger.LogInformation("Migration postgrss started.");
                    var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();
                    using var command = new NpgsqlCommand { 
                        Connection = connection
                    };
                    command.CommandText = "DROP TABLE IF EXISTS coupon";
                    command.ExecuteNonQuery();
                    command.CommandText = @"create table Coupon (
                                            Id serial primary key not null,
	                                        ProductName varchar(24) not null,
	                                        Description text,
                                            Amount decimal
                                        ); ";
                    command.ExecuteNonQuery();

                    // insert record 
                    command.CommandText = "insert into coupon (ProductName, Description,Amount) values ('Smart phone','Discount for smart phone',10)";
                    command.ExecuteNonQuery();

                    command.CommandText = "insert into coupon (ProductName, Description,Amount) values ('Cloths','Discount for Cloths',20)";
                    command.ExecuteNonQuery();

                    logger.LogInformation("Migrated postgrss database.");
                }
                catch(Exception ex)
                {
                    logger.LogError(ex,"An error occured while Migrating postgrss database.");
                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                } 
            }
            return host;
        }
    }
}
