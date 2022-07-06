using DailySharePrice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DailySharePrice.Respository
{
    public interface IStockRepository<StockDetail>
    {
        public List<StockDetail> GetAllStocks();
        public StockDetail GetStockByName(string StockName);

        
    }
}
