namespace LondonStockExchangeApi.Models.Request
{
    public record StockDetailsRequest
    {
        public string tickerSymbol { get; set; }
        public decimal price { get; set; }
        public decimal numberOfShares { get; set; }
        public string traderId { get; set; }
    }
}
