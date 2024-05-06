using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Portfolios.Domain;
using StockMarket.Features.Portfolios.Application;
using StockMarket.Shared.Data;

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
        public ActionResult<PortfolioDto> GetPortfolio(PortfolioId id)
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

        [HttpPut]
        public ActionResult<PortfolioDto> PutPortfolio(PortfolioDto portfolio)
        {
            _service.Update(portfolio);
            return Ok(portfolio);
        }

        [HttpDelete]
        public ActionResult<PortfolioDto> DeletePortfolio(PortfolioId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
