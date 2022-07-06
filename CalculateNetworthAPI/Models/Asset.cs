using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Models
{
    public class Asset
    {

        public List<StockDetail> stockDetails;
        public List<MutualFund> mutualFund;
        public Asset(List<StockDetail> myStocks1, List<MutualFund> myMutualFunds1)
        {
            stockDetails = myStocks1;
            mutualFund = myMutualFunds1;
        }
    }
}
