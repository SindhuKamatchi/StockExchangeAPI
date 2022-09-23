using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LondonStockExchangeApi.Interface;
using LondonStockExchangeApi.Models.Request;
using LondonStockExchangeApi.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LondonStockExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDetailsController : Controller
    {
        private readonly IStockService _stockService ;
        private readonly ILogger<StockDetailsController> _logger;
        public StockDetailsController(IStockService stockService, ILogger<StockDetailsController> logger)
        {
            _stockService = stockService;
            _logger = logger;
        }

        [HttpGet("GetStockDetails")]
        public async Task<IActionResult> StocksInformation([FromBody] List<string> tickerSymbols)
        {
            try
            {
                _logger.LogInformation("Request received for /Information");
                if (tickerSymbols == null || !tickerSymbols.Any())
                {
                    _logger.LogInformation("Bad Request received for /Information {0}",tickerSymbols);
                    return NotFound();
                }
                

                var StockList = new List<StockDetails>();
                foreach (var stockSymbol in tickerSymbols)
                {
                    var stock = await _stockService.GetStockByTickerSymbol(stockSymbol);

                    if (stock != null) StockList.Add(stock);
                }
                return Ok(StockList);
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Exception {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveStockDetails")]
        public async Task<IActionResult> SaveStockTransactionDetails(StockDetailsRequest stockDetailsRequest)
        {
            try
            {
                _logger.LogInformation("Request received for /Transaction");

                if (!string.IsNullOrEmpty(stockDetailsRequest.traderId))
                {
                    _logger.LogInformation("Calling GetTraderByTraderId {0}", stockDetailsRequest.traderId);
                    var trader = await _stockService.GetTraderByTraderId(stockDetailsRequest.traderId);

                    if (trader == null)
                        _logger.LogInformation("Broker not found {0}", stockDetailsRequest.traderId);
                    return NotFound();
                }
                 
                if (!string.IsNullOrEmpty(stockDetailsRequest.tickerSymbol))
                {

                    _logger.LogInformation("Calling GetTraderByTraderId {0}", stockDetailsRequest.tickerSymbol);
                    var stock = await _stockService.GetTraderByTraderId(stockDetailsRequest.tickerSymbol);

                    if (stock == null)
                        _logger.LogInformation("stock details is empty {0}", stockDetailsRequest.tickerSymbol);
                    return NotFound();
                }

                if (stockDetailsRequest.price <= 0.0m)
                {
                    _logger.LogInformation("Price not valid {0}", stockDetailsRequest.price);
                    return BadRequest();
                }

                if (stockDetailsRequest.numberOfShares < 0.0m)
                {
                    _logger.LogInformation("Number of Shares not valid {0}", stockDetailsRequest.numberOfShares);
                    return BadRequest();
                }

                var status = await _stockService.SaveStockDetails(stockDetailsRequest);
                if (status)
                    return Ok("Stock details saved successfully");
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Exception {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
