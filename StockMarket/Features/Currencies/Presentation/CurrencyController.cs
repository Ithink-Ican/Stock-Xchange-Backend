using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StockMarket.Features.Currencies.Domain;
using StockMarket.Features.Currencies.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Currencies.Presentation;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _service;

    public CurrencyController()
    {
        _service = new CurrencyService();
    }

    [HttpPost]
    public ActionResult<CurrencyDto> Post(CurrencyDto currencyDto)
    {
        _service.Create(currencyDto);
        return currencyDto;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CurrencyDto>> GetAll()
    {
        var dto = new CurrencyDto();
        var currencies = _service.GetAll().Result;
        var dtos = dto.BulkConvert(currencies);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public ActionResult<CurrencyDto> GetById([FromQuery] CurrencyId id)
    {
        var currency = _service.Get(id).Result;
        var dto = CurrencyDto.Create(
                currency.Id,
                currency.IntCode,
                currency.ChrCode,
                currency.Amount,
                currency.Name,
                currency.Rate
            );
        return Ok(dto);
    }

    [HttpPut]
    public ActionResult<CurrencyDto> Put(CurrencyDto currency)
    {
        _service.Update(currency);
        return Ok(currency);
    }

    [HttpDelete]
    public ActionResult<CurrencyDto> Delete([FromQuery] CurrencyId id)
    {
        _service.Delete(id);
        return Ok(id);
    }
}
