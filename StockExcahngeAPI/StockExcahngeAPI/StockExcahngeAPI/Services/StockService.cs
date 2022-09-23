using System;
using System.Threading.Tasks;
using LondonStockExchangeApi.Interface;
using LondonStockExchangeApi.Models.Request;
using LondonStockExchangeApi.Models.Response;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace LondonStockExchangeApi.Client
{
    public class StockService : IStockService
    {
        private readonly ILogger<StockService> _logger;

        public StockService(ILogger<StockService> logger)
        {
            _logger = logger;
        }
        public async Task<bool> SaveStockDetails(StockDetailsRequest stockDetailsRequest)
        {
            try
            {
                // Save data to database
                _logger.LogInformation("Save StockDetails Success");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Save StockDetails failure");
                return false;
            }
        }

        public async Task<StockDetails> GetStockByTickerSymbol(string tickerSymbol)
        {
            StockDetails StockDetails = new StockDetails();
            try
            {

                _logger.LogInformation("GetStockByTickerSymbol Success");
                //StockDetails = getStockDetails from DB with using statement 
            }
            catch(Exception ex)
            {

                _logger.LogInformation("GetStockByTickerSymbol failure");

            }
            return StockDetails;
        }

        public async Task<TraderDetails> GetTraderByTraderId(string traderId)
        {

            TraderDetails TraderDetails = new TraderDetails();
            try
            {
                 _logger.LogInformation("GetTraderByTraderId success"); 
                //StockDetails = getStockDetails from DB with using statement 
            }
            catch (Exception ex)
            {
                _logger.LogInformation("GetTraderByTraderId failure");
            }
            return TraderDetails;
        }
    }
}
