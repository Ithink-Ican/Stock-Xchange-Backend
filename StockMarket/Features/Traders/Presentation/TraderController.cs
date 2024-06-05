using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Traders.Application;
using StockMarket.Shared.Data;
using StockMarket.Features.Users.Domain;

namespace StockMarket.Features.Traders.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class TraderController : ControllerBase
    {
        private ITraderService _service;

        public TraderController()
        {
            _service = new TraderService();
        }

        [HttpPost]
        public ActionResult<TraderDto> PostTrader(TraderDto traderDto)
        {
            _service.Create(traderDto);
            return traderDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TraderDto>> GetTraders()
        {
            var dto = new TraderDto();
            var traders = _service.GetAll().Result;
            var dtos = dto.BulkConvert(traders);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<TraderDto> GetTrader(TraderId id)
        {
            var trader = _service.Get(id).Result;
            var dto = TraderDto.Create(
                trader.Id,
                trader.Name,
                trader.INN,
                trader.UserId
                );
            return Ok(dto);
        }

        [HttpGet("/trader-by-user")]
        public ActionResult<TraderDto> GetByUserId([FromQuery] UserId id)
        {
            var trader = _service.GetByUserId(id).Result;
            if (trader == null)
            {
                return NotFound();
            }
            var dto = TraderDto.Create(
                trader.Id,
                trader.Name,
                trader.INN,
                trader.UserId
                );
            return Ok(dto);
        }

        [HttpPut]
        public ActionResult<TraderDto> PutTrader(TraderDto trader)
        {
            _service.Update(trader);
            return Ok(trader);
        }

        [HttpDelete]
        public ActionResult<TraderDto> DeleteTrader([FromQuery] TraderId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
