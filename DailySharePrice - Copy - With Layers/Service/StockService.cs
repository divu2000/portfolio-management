using DailySharePrice.Models;
using DailySharePrice.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePrice.Service
{
    public class StockService:IStockService<StockDetail>
    {
        private readonly IStockRepository<StockDetail> _stockRepository;
       
        public StockService(IStockRepository<StockDetail> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public List<StockDetail> GetAllStocks()
        {
            return _stockRepository.GetAllStocks();
        } 
        
        public StockDetail GetStockByName(string StockName)
        {

            return _stockRepository.GetStockByName(StockName);
            

        }
    }
}
