using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.InstrumentTypes.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.InstrumentTypes.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentTypeController : ControllerBase
    {
        private readonly IInstrumentTypeService _service;

        public InstrumentTypeController()
        {
            _service = new InstrumentTypeService();
        }

        [HttpPost]
        public ActionResult<InstrumentTypeDto> PostInstrumentType(InstrumentTypeDto instrumentTypeDto)
        {
            _service.Create(instrumentTypeDto);
            return instrumentTypeDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InstrumentTypeDto>> GetInstrumentTypes()
        {
            var dto = new InstrumentTypeDto();
            var instrumentTypes = _service.GetAll().Result;
            var dtos = dto.BulkConvert(instrumentTypes);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<InstrumentTypeDto> GetInstrumentType(InstrumentTypeId id)
        {
            var instrumentType = _service.Get(id).Result;
            var dto = InstrumentTypeDto.Create(
                instrumentType.Id,
                instrumentType.Name
                );
            return Ok(dto);
        }

        [HttpPut]
        public ActionResult<InstrumentTypeDto> PutInstrumentType(InstrumentTypeDto instrumentType)
        {
            _service.Update(instrumentType);
            return Ok(instrumentType);
        }

        [HttpDelete]
        public ActionResult<InstrumentTypeDto> DeleteInstrumentType(InstrumentTypeId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
