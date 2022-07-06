using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<PortfolioDetail> PortfolioDetails { get; set; }
        public virtual DbSet<StockInfo> StockInfo { get; set; }
        public DbSet<MutualFundDetail> MutualFundDetails { get; set; }
        public DbSet<AssetSaleResponse> AssetSaleResponses { get; set; }
    }
}
