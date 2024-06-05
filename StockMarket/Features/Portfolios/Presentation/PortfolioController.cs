using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Portfolios.Domain;
using StockMarket.Features.Portfolios.Application;
using StockMarket.Shared.Data;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Instruments.Domain;

namespace StockMarket.Features.Portfolios.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private IPortfolioService _service;

        public PortfolioController()
        {
            _service = new PortfolioService();
        }

        [HttpPost]
        public ActionResult<PortfolioDto> PostPortfolio(PortfolioDto portfolioDto)
        {
            _service.Create(portfolioDto);
            return portfolioDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PortfolioDto>> GetPortfolios()
        {
            var dto = new PortfolioDto();
            var portfolios = _service.GetAll().Result;
            var dtos = dto.BulkConvert(portfolios);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PortfolioDto> GetPortfolio([FromQuery] PortfolioId id)
        {
            var portfolio = _service.Get(id).Result;
            var dto = PortfolioDto.Create(
                portfolio.Id,
                portfolio.TraderId,
                portfolio.InstrumentId,
                portfolio.Amount
                );
            return Ok(dto);
        }


        [HttpGet("/by-trader")]
        public ActionResult<IEnumerable<PortfolioDto>> GetByTrader(TraderId id)
        {
            var portfolios = _service.GetByTrader(id);
            return Ok(portfolios);
        }

        [HttpGet("/by-trader-instrument")]
        public ActionResult<PortfolioDto> GetByTraderInstrument([FromQuery]Guid id, [FromQuery]Guid instrumentId)
        {
            var portfolio = _service.GetByTraderInstrument(id, instrumentId);
            return Ok(portfolio);
        }

        [HttpGet("/trader-portfolio")]
        public ActionResult<IEnumerable<PortfolioDto>> GetTraderPortfolio([FromQuery] TraderId id)
        {
            var portfolios = _service.GetTraderPortfolio(id);
            return Ok(portfolios);
        }

        [HttpPut]
        public ActionResult<PortfolioDto> PutPortfolio(PortfolioDto portfolio)
        {
            _service.Update(portfolio);
            return Ok(portfolio);
        }

        [HttpPost("/portfolio/buy")]
        public ActionResult Buy(Portfolio portfolio)
        {
            _service.Buy(portfolio);
            return Ok();
        }

        [HttpPut("/portfolio/sell")]
        public ActionResult Sell([FromQuery]PortfolioId id, [FromQuery]int amount)
        {
            _service.Sell(id, amount);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<PortfolioDto> DeletePortfolio(PortfolioId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
