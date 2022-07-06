using DailyMutualFundNAV.Models;
using DailyMutualFundNAV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNAV.Services
{
    public class MutualFundService : IMutualFundService<MutualFund>
    {
        private readonly IMutualFundRepository<MutualFund> _mutualFundRepository;

        public MutualFundService(IMutualFundRepository<MutualFund> mutualFundRepository)
        {
            _mutualFundRepository = mutualFundRepository;
        }
        public List<MutualFund> GetAllMutualFunds()
        {
            return _mutualFundRepository.GetAllMutualFunds();
        }

        public MutualFund GetMutualFundByName(string mutualFundName)
        {
            return _mutualFundRepository.GetMutualFundByName(mutualFundName);
        }
    }
}
