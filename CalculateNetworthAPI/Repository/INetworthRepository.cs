using CalculateNetworth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworth.Services
{
    public interface INetworthRepository
    {
        public MyAsset GetPortfolioDetailsById(int id);

        //public Task<List<StockDetail>> GetAssetDetails();
        //public Task<Asset> GetAssetDetails();

        public Task<Asset> GetAllAssetDetails();

        //public AssetSaleResponse SellAssets(List<PortfolioDetail> assetDetails);

        public Task<List<StockInfo>> ViewStockHoldings(int id);

        public Task<List<MutualFundDetail>> ViewMutualFunds(int id);

        //public Task<List<PortfolioDetail>> SellAssets(string stockToSell, int unitsToSell, int portfolioId);

        public Task<List<PortfolioDetail>> GetMyPortfolio(int portfolioId);

        public Task<PortfolioDetail> SellAssets(StockInfo stockToRemove, int numberOfSharesToSell);

        public void SellMutualFund(MutualFundDetail fundToSell, int numberOfUnitssToSell);

        public void RemoveAsset(StockInfo stockToSell);

        public void RemoveMutualFund(MutualFundDetail fundToSell);

    }
}
