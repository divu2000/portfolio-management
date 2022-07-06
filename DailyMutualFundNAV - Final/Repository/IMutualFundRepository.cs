using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNAV.Repository
{
    public interface IMutualFundRepository<MutualFund>
    {
        public List<MutualFund> GetAllMutualFunds();
        public MutualFund GetMutualFundByName(string MutualFundName);
    }
}
