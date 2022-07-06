using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Models
{
    public class MutualFundDetail
    {
        [Key]
        public int Id { get; set; }
        public string MutualFundName { get; set; }
        public int MutualFundUnits { get; set; }
    }
}
