using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePrice.Models
{
    public class StockDetail
    {
        public int Id { get; set; }
        public string StockName { get; set; }

        public double StockValue { get; set; }
    }
}
