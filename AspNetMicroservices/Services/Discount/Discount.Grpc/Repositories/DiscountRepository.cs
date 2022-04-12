using Dapper;
using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync("insert into coupon (productname,description,amount) values (@ProductName,@Decription,@Amount)", new { 
                ProductName = coupon.ProductName,Decription = coupon.Description, Amount = coupon.Amount
            });
            if(affected == 0)
                return false;
            return true;

        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync("delete from coupon where productname=@ProductName", new
            {
                ProductName = productName
            });
            if (affected == 0)
                return false;
            return true;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("select *from coupon where productname = @ProductName", new { ProductName =  productName});
            if(coupon == null)
            {
                return new Coupon() { };
            }
            return coupon;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync("update coupon set productname=@ProductName, set description=@Decription, set amount=@Amount", new
            {
                ProductName = coupon.ProductName,
                Decription = coupon.Description,
                Amount = coupon.Amount
            });
            if (affected == 0)
                return false;
            return true;
        }
    }
}
