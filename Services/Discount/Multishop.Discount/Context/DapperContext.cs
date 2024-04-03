using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Multishop.Discount.Entities;
using System.Data;

namespace Multishop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQL; initial Catalog=MultiShopDiscountDb;User Id=sa;Password=kenan4258;integrated security = true");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection("Server=localhost\\SQL; initial Catalog=MultiShopDiscountDb;User Id=sa;Password=kenan4258;integrated security = true");  // For Dapper
    }
}