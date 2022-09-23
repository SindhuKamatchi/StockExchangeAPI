using LondonStockExchangeApi.Models.Request;
using LondonStockExchangeApi.Models.Response;
using System.Threading.Tasks;

namespace LondonStockExchangeApi.Interface
{
    public interface IStockService
    {
        Task<bool> SaveStockDetails(StockDetailsRequest stockDetailsRequest);
        Task<StockDetails> GetStockByTickerSymbol(string tickerSymbol);
        Task<TraderDetails> GetTraderByTraderId(string traderId);
    }
}
