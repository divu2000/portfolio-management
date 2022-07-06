using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Models
{
    public class AssetSaleResponse
    {
        [Key]
        public int ResponseId { get; set; }

        public bool SaleStatus { get; set; }
        public double NetWorth { get; set; }
    }
}
