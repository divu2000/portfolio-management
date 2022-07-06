using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Models
{
    public class StockDetail
    {
        
        public int Id { get; set; }
        public string StockName { get; set; }

        public double StockValue { get; set; }
    }
}
