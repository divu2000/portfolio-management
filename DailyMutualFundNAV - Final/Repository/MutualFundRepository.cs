using DailyMutualFundNAV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNAV.Repository
{
    public class MutualFundRepository:IMutualFundRepository<MutualFund>
    {
        private readonly AppDbContext _context;

        public MutualFundRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public List<MutualFund> GetAllMutualFunds()
        {
            return _context.MutualFunds.ToList();
        }

       
        public MutualFund GetMutualFundByName(string mutualFundName)
        {
            MutualFund mf = _context.MutualFunds.FirstOrDefault(n => n.MutualFundName == mutualFundName);
            return mf;
        }

        
    }
}
