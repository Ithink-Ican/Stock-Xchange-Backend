using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Deals.Domain;
using StockMarket.Features.Deals.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Deals.Presentation;

[ApiController]
[Route("[controller]")]
public class DealController : ControllerBase
{
    private readonly IDealService _service;

    public DealController()
    {
        _service = new DealService();
    }

    [HttpPost]
    public ActionResult<DealDto> Post(DealDto dealDto)
    {
        _service.Create(dealDto);
        return dealDto;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DealDto>> GetAll()
    {
        var dto = new DealDto();
        var deals = _service.GetAll().Result;
        var dtos = dto.BulkConvert(deals);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public ActionResult<DealDto> GetById(DealId id)
    {
        var deal = _service.Get(id).Result;
        var dto = DealDto.Create(
                deal.Id,
                deal.SellOfferId,
                deal.BuyOfferId
            );
        return Ok(dto);
    }

    [HttpPut]
    public ActionResult<DealDto> Put(DealDto deal)
    {
        _service.Update(deal);
        return Ok(deal);
    }

    [HttpDelete]
    public ActionResult<DealDto> Delete(DealId id)
    {
        _service.Delete(id);
        return Ok(id);
    }
}
