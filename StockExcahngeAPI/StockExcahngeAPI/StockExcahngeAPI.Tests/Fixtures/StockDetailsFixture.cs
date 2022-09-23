using LondonStockExchangeApi.Models.Request;

namespace LondonStockExchangeApi.Tests.Fixtures
{
    public class StockDetailsFixture
    {
        public static StockDetailsRequest stockDetailsValidRequest => new StockDetailsRequest()
        {
             numberOfShares = 1,
             price  =   250,
             tickerSymbol="TX",
             traderId="AC1"
        };

        public static StockDetailsRequest stockDetailsInValidRequest => new StockDetailsRequest()
        {
            numberOfShares = 1,
            price = 0,
            tickerSymbol = String.Empty,
            traderId = String.Empty
        };
    }
}
