using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CalculateNetworth.Models
{
    
    public class StockInfo
    {
        [Key]
        public int Id { get; set; }

        public int Profile_Id { get; set; }
        public string StockName { get; set; }
        
        public int StockCount { get; set; }
    }
}
