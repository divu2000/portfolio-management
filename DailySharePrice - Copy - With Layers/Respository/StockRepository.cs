using DailySharePrice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePrice.Respository
{
    public class StockRepository : IStockRepository<StockDetail>
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StockRepository));

        private readonly AppDbContext _context;
        

        public StockRepository(AppDbContext context)
        {
            _context = context;

        }

        public List<StockDetail> GetAllStocks() => _context.StockDetails.ToList();


        //public StockDetail GetStockByName(string _StockName) => _context.StockDetails.FirstOrDefault(n => n.StockName == _StockName);
        public StockDetail GetStockByName(string StockName)
        {

            
            _log4net.Info("Fetching Stock details from DB based on users's portfolio Id");
            StockDetail stockinfo = _context.StockDetails.FirstOrDefault(n => n.StockName == StockName);


            return stockinfo;

        }
    }
}
