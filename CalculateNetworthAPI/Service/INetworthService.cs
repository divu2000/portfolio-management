using CalculateNetworth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Service
{
    public interface INetworthService
    {
        

        public Task<Asset> GetAssetDetails();

        public Task<double> CalculateNetworth(int id);


        //public AssetSaleResponse SellAssets(List<PortfolioDetail> listOfCurrentHoldingsAndAssetsToSell);

        
        public Task<List<StockInfo>> ViewStockHoldings(int id);

        public Task<List<MutualFundDetail>> ViewMutualFunds(int id);

        public Task<List<PortfolioDetail>> GetMyPortfolio(int portfolioId);

        public Task<AssetSaleResponse> SellAssets(int id, string stockName, int stockCount);

        


        //public Task<AssetSaleResponse> SellAssets(PortfolioDetail portfolioDetail);

        //public Task<PortfolioDetail> SellAssets(PortfolioDetail portfolioDetail);



        //public Task<AssetSaleResponse> SellAssets(string stockToSell, int unitsToSell, int portfolioId);



    }
}
