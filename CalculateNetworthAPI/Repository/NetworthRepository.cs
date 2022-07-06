using CalculateNetworth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Http;
using CalculateNetworth.Service;

namespace CalculateNetworth.Services
{
    public class NetworthRepository : INetworthRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(NetworthRepository));
        private AppDbContext _context;
        private readonly INetworthService _networthService;
        List<StockInfo> myStocks;
        List<MutualFundDetail> myMutualFunds;

        public NetWorth networth = new NetWorth();

        public NetworthRepository(AppDbContext context)
        {
            _context = context;

        }
        List<PortfolioDetail> myPortfolioStocks;
        List<PortfolioDetail> myPortfolioMFs;


        /// <summary>
        /// Fetches all athe assets held by user from DB and returns them to the service layer for net worth calculation
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id, Name and count of the assets belonging to a user</returns>
        public MyAsset GetPortfolioDetailsById(int id)
        {
            
            myPortfolioStocks = _context.PortfolioDetails.Include(x => x.StockList).Where(x => x.PortfolioId == id).ToList();

            myPortfolioMFs = _context.PortfolioDetails.Include(x => x.MutualFundList).Where(x => x.PortfolioId == id).ToList();

            //myPortfolio = _context.PortfolioDetails.Where(x => x.PortfolioId == id).ToList();

            myStocks = myPortfolioStocks[0].StockList;
            myMutualFunds = myPortfolioMFs[0].MutualFundList;

            MyAsset myAssets = new MyAsset(myStocks, myMutualFunds);

           
            return myAssets;

        }

        List<StockDetail> allStockInfo = new List<StockDetail>();
        List<MutualFund> allMutualFundInfo = new List<MutualFund>();



        /// <summary>
        /// Calls DailySharePrice  and DailyMutualFundNetAssetValue APIs which in turn fetch all the assets from DB whether they are held/not held by a user and return to this method
        /// </summary>
        /// <returns>Mutual funds and stocks held/not held by user to service layer for net worth calculation</returns>
        public async Task<Asset> GetAllAssetDetails()
        {
           
            //Call to DailySharePrice API
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44378/api/StockDetails/get-all-stocks");
                if (Res.IsSuccessStatusCode)
                {
                    var ApiResponse = Res.Content.ReadAsStringAsync().Result;
                    allStockInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StockDetail>>(ApiResponse);
                }


            }

            //Call to Daily_Mutual_Fund_Net_Asset_Value API
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44303/api/MutualFund/get-all-mutualFunds");
                if (Res.IsSuccessStatusCode)
                {
                    var ApiResponse = Res.Content.ReadAsStringAsync().Result;
                    allMutualFundInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MutualFund>>(ApiResponse);

                }

            }
            Asset asset = new Asset(allStockInfo, allMutualFundInfo);

            return asset;

        }

        /// <summary>
        /// Fetches stock holdings of a user from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of all stock objects containing stock name and number of shares held</returns>
        public async Task<List<StockInfo>> ViewStockHoldings(int id)
        {
            List<PortfolioDetail> myHoldings = _context.PortfolioDetails.Include(x => x.StockList).Where(x => x.PortfolioId == id).ToList();

            return myHoldings[0].StockList;
        }

        /// <summary>
        /// Fetches all the mutual funds from Db held by a user 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of mutual fund object containing fund name and number of units held</returns>
        public async Task<List<MutualFundDetail>> ViewMutualFunds(int id)
        {

            List<PortfolioDetail> myFunds = _context.PortfolioDetails.Include(x => x.MutualFundList).Where(x => x.PortfolioId == id).ToList();
            return myFunds[0].MutualFundList;

        }


        public async Task<List<PortfolioDetail>> GetMyPortfolio(int portfolioId)
        {

            List<PortfolioDetail> myPortfolio = _context.PortfolioDetails.ToList();
            return myPortfolio;

        }

        public async Task<PortfolioDetail> SellAssets(StockInfo stockToSell, int numberOfSharesToSell)
        {
            

            stockToSell.StockCount = stockToSell.StockCount - numberOfSharesToSell;
           // _context.StockInfo.Update(stockToRemove.StockCount = 1);
            _context.StockInfo.Update(stockToSell);
            _context.SaveChanges();

            PortfolioDetail portfolioDetail = new PortfolioDetail();
            return portfolioDetail;

        }
        public async void SellMutualFund(MutualFundDetail fundToSell, int numberOfUnitssToSell)
        {


            fundToSell.MutualFundUnits = fundToSell.MutualFundUnits - numberOfUnitssToSell;
            // _context.StockInfo.Update(stockToRemove.StockCount = 1);
            _context.MutualFundDetails.Update(fundToSell);
            _context.SaveChanges();

        }
        public async void RemoveAsset(StockInfo stockToSell)
        {
            _context.Remove(stockToSell);
            _context.SaveChanges();
        }

        public async void RemoveMutualFund(MutualFundDetail fundToSell)
        {
            _context.Remove(fundToSell);
            _context.SaveChanges();
        }

    }

}

