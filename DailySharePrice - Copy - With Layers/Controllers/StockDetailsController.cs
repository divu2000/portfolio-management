using DailySharePrice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using DailySharePrice.Respository;
using DailySharePrice.Service;

namespace DailySharePrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDetailsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StockDetailsController));
        public IStockService<StockDetail> _stockService;
        public StockDetailsController(IStockService<StockDetail> stockService)
        {
            _stockService = stockService;
        }

        /// <summary>
        /// Returns all the stocks from database
        /// </summary>
        /// <returns>Information of all stocks from StockDetail table</returns>
        [HttpGet("get-all-stocks")]
        public IActionResult GetAllStocks()
        {
            _log4net.Info("GetAllStocks() called");
            var allStocks = _stockService.GetAllStocks();
            return Ok(allStocks);

        }


        /// <summary>
        /// Returns the details of a stock(Id, name and Stock value) based on the name provided
        /// </summary>
        /// <param name="StockName">Name of the required stock</param>
        /// <returns>Information of a particular stock from StockDetils table as JSON object</returns>
        [HttpGet("get-StockDetails-by-Name/{StockName}")]
        public IActionResult GetStockByName(string StockName)
        {
           var stock = _stockService.GetStockByName(StockName);
           return Ok(stock);

        }
    }
}
