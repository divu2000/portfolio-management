using DailyMutualFundNAV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNAV.Services
{
    public interface IMutualFundService<MutualFund>
    {
        public List<MutualFund> GetAllMutualFunds();
        public MutualFund GetMutualFundByName(string mutualFundName);
    }
}
