using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Offers.Domain;
using StockMarket.Features.Offers.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Offers.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        private IOfferService _service;

        public OfferController()
        {
            _service = new OfferService();
        }

        [HttpPost]
        public ActionResult<OfferDto> PostOffer(OfferDto offerDto)
        {
            _service.Create(offerDto);
            return offerDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OfferDto>> GetOffers()
        {
            var dto = new OfferDto();
            var offers = _service.GetAll().Result;
            var dtos = dto.BulkConvert(offers);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<OfferDto> GetOffer(OfferId id)
        {
            var offer = _service.Get(id).Result;
            var dto = OfferDto.Create(
                offer.Id,
                offer.TraderId,
                offer.InstrumentId,
                offer.Amount,
                offer.Price,
                offer.CurrencyId,
                offer.IsSale
                );
            return Ok(dto);
        }

        [HttpPut]
        public ActionResult<OfferDto> PutOffer(OfferDto offer)
        {
            _service.Update(offer);
            return Ok(offer);
        }

        [HttpDelete]
        public ActionResult<OfferDto> DeleteOffer(OfferId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
