using DailyMutualFundNAV.Models;
using DailyMutualFundNAV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNAV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutualFundController : ControllerBase
    {
        public IMutualFundService<MutualFund> _mutualFundService;
        public MutualFundController(IMutualFundService<MutualFund> mutualFundService)
        {
            _mutualFundService = mutualFundService;
        }

        [HttpGet("get-all-mutualFunds")]
        public IActionResult GetAllMutualFunds()
        {
            var allMutualFunds = _mutualFundService.GetAllMutualFunds();
            return Ok(allMutualFunds);

        }

        //public StockDetail GetStockByName(string _StockName) => _context.StockDetails.FirstOrDefault(n => n.StockName == _StockName);

        [HttpGet("get-MutualFundDetails-by-Name/{mutualFundName}")]
        public IActionResult GetMutualFundByName(string mutualFundName)
        {
            var netAssetValue = _mutualFundService.GetMutualFundByName(mutualFundName);
            return Ok(netAssetValue);

        }
    }
}
