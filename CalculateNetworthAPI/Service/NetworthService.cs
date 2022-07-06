using CalculateNetworth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculateNetworth.Models;

namespace CalculateNetworth.Service
{
    public class NetworthService:INetworthService
    {
        private readonly INetworthRepository _networthRepo;
        public INetworthService _networthService;
        public NetWorth networth = new NetWorth();
        MyAsset myPortfolio;

        public NetworthService(INetworthRepository networthRepo)
        {
            _networthRepo = networthRepo;
        }

        /// <summary>
        /// This method calculates the the networth of a user. All the assets, their current price and the number of units that a user holds will be fetched from the database using the portfolio id provided to calculte net worth amount
        /// </summary>
        /// <param name="portfolioId"></param>
        /// <returns>Net worth of a user</returns>

        public async Task<double> CalculateNetworth(int portfolioId)
        {
            myPortfolio = _networthRepo.GetPortfolioDetailsById(portfolioId);
            Asset allAssets = await _networthRepo.GetAllAssetDetails(); //returns all assets inclusive of the assets held by user

            var _stock = "";
            var _mutualFund = "";
            foreach (var stock in allAssets.stockDetails)
            {
                _stock = stock.StockName;
                var _stockValue = stock.StockValue;
                foreach (var portfolioStock in myPortfolio.myStocks.Where(x => x.StockName == _stock))
                {
                    networth.NetworthAmount += portfolioStock.StockCount * _stockValue;

                }

            }

            foreach (var mutualFund in allAssets.mutualFund)
            {
                _mutualFund = mutualFund.MutualFundName;
                var _mutualFundValue = mutualFund.MutualFundValue;
                foreach (var portfolioMF in myPortfolio.myMutualFunds.Where(x => x.MutualFundName == _mutualFund))
                {
                    networth.NetworthAmount += portfolioMF.MutualFundUnits * _mutualFundValue;

                }

            }
            networth.NetworthAmount = Math.Round(networth.NetworthAmount, 2);
            return networth.NetworthAmount;
            
        }

        /// <summary>
        /// Calls ViewStockHoldings() in repository layer to fetch all the stock details that a user holds
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StockInfo object containing stock Id,name,stock count</returns>
        public async Task<List<StockInfo>> ViewStockHoldings(int id)
        {

            List<StockInfo> myStocks = await _networthRepo.ViewStockHoldings(id);
            return myStocks;

        }

        //Returns complete information about all stocks and mutual funds in the database
        public async Task<Asset> GetAssetDetails()
        {
            Asset allAssets = await _networthRepo.GetAllAssetDetails();
            return allAssets;
        }

        public async Task<List<MutualFundDetail>> ViewMutualFunds(int id)
        {

            List<MutualFundDetail> myFunds = await _networthRepo.ViewMutualFunds(id);
            return myFunds;

        }

        public async Task<List<PortfolioDetail>> GetMyPortfolio(int portfolioId)
        {

            List<PortfolioDetail> myPortfolio = await _networthRepo.GetMyPortfolio(portfolioId);

            return myPortfolio;
        }

        public async Task<AssetSaleResponse> SellAssets(int id, string assetName, int numberOfUnitsToSell)
        {
            List<PortfolioDetail> myportfolioDetails = new List<PortfolioDetail>();
            myportfolioDetails = await _networthRepo.GetMyPortfolio(id);

            AssetSaleResponse assetSaleResponse = new AssetSaleResponse();

            NetWorth networth = new NetWorth();
            

            StockInfo stockToRemove = new StockInfo();
            MutualFundDetail fundsToRemove = new MutualFundDetail();

            PortfolioDetail updatedPortfolio = new PortfolioDetail();
            int flag = 0;
            double currentNetworth = await CalculateNetworth(id);
            foreach (PortfolioDetail myPortfolio in myportfolioDetails)
            {
                if (myPortfolio.PortfolioId == id)
                {
                    List<StockInfo> myStockList = await _networthRepo.ViewStockHoldings(id);
                    foreach(var myStock in myStockList)
                    {
                        if(myStock.StockName == assetName)
                        {
                            if(myStock.StockCount == numberOfUnitsToSell)
                            {
                                _networthRepo.RemoveAsset(myStock);
                                flag = 1;
                            }
                            else if(myStock.StockCount >= numberOfUnitsToSell)
                            {
                                updatedPortfolio = await _networthRepo.SellAssets(myStock, numberOfUnitsToSell);
                                flag = 1;
                            }

                            
                            break;
                        }
                    }
                 
                }
            }
            foreach (PortfolioDetail myPortfolio in myportfolioDetails)
            {
                if (myPortfolio.PortfolioId == id)
                {
                    List<MutualFundDetail> myMutualFundsList = await _networthRepo.ViewMutualFunds(id);
                    
                    foreach (var myMutualFund in myMutualFundsList)
                    {
                        if (myMutualFund.MutualFundName == assetName)
                        {
                            if (myMutualFund.MutualFundUnits == numberOfUnitsToSell)
                            {
                                _networthRepo.RemoveMutualFund(myMutualFund);
                                flag = 1;
                            }
                            else if (myMutualFund.MutualFundUnits >= numberOfUnitsToSell)
                            {
                                _networthRepo.SellMutualFund(myMutualFund, numberOfUnitsToSell);
                                flag = 1;
                            }

                            break;

                        }
                    }

                }
            }
            assetSaleResponse.NetWorth = await CalculateNetworth(id);

            if (flag == 1)
            {
                //networth.NetworthAmount = await CalculateNetworth(id);
                assetSaleResponse.ResponseId = assetSaleResponse.ResponseId + 1;
                assetSaleResponse.SaleStatus = true;
            }
            else
            {
                assetSaleResponse.SaleStatus = false;
            }
            

            return assetSaleResponse;
        }

        //public AssetSaleResponse SellAssets(List<PortfolioDetail> listOfCurrentHoldingsAndAssetsToSell)
        //{
        //    AssetSaleResponse a = new AssetSaleResponse();
        //    return a;
        //}


    }
}
