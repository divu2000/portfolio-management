using DailySharePrice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePrice.Service
{
    public interface IStockService<StockDetail>
    {
        public List<StockDetail> GetAllStocks();
        public StockDetail GetStockByName(string StockName);
    }
}
