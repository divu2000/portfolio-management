using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Models
{
    public class MyAsset
    {
        public List<StockInfo> myStocks;
        public List<MutualFundDetail> myMutualFunds;

        public MyAsset(List<StockInfo> myStocks1, List<MutualFundDetail> myMutualFunds1)
        {
            myStocks = myStocks1;
            myMutualFunds = myMutualFunds1;
        }
    }
}
