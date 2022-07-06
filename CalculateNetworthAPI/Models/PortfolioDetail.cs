using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Models
{
    public class PortfolioDetail
    {
        [Key]
        public int PortfolioId { get; set; }

        public string Username { get; set; }
        public List<StockInfo> StockList { get; set; }

        public List<MutualFundDetail> MutualFundList { get; set; }
    }
}
