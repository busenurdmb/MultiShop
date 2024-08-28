using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DiscountDapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DiscountDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-493DFJA\\SQLEXPRESS;initial Catalog=MultiShopDiscountDb;integrated Security=true;TrustServerCertificate=True;");
        //}
        public DbSet<Coupon> Coupons{ get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
