using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.Instruments.Application;
using StockMarket.Shared.Data;
using StockMarket.Features.InstrumentTypes.Domain;

namespace StockMarket.Features.Instruments.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController : ControllerBase
    {
        private IInstrumentService _service;

        public InstrumentController()
        {
            _service = new InstrumentService();
        }

        [HttpPost]
        public ActionResult<InstrumentDto> PostInstrument(InstrumentDto instrumentDto)
        {
            _service.Create(instrumentDto);
            return instrumentDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InstrumentDto>> GetInstruments()
        {
            var dto = new InstrumentDto();
            var instruments = _service.GetAll().Result;
            var dtos = dto.BulkConvert(instruments);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<InstrumentDto> GetInstrument(InstrumentId id)
        {
            var instrument = _service.Get(id);
            return Ok(instrument);
        }

        [HttpGet("/Instrument/by-code/{code}")]
        public ActionResult<InstrumentDto> GetByCode(string code)
        {
            var instrument = _service.GetByCode(code);
            return Ok(instrument);
        }

        [HttpGet("/Instruments/by-type")]
        public ActionResult<IEnumerable<InstrumentDto>> GetByType([FromQuery] InstrumentTypeId typeId)
        {
            var instruments = _service.GetByType(typeId);
            if (instruments.Count != 0)
            {
                return instruments;
            }
            return NotFound();
        }

        [HttpPut]
        public ActionResult<InstrumentDto> PutInstrument(InstrumentDto instrument)
        {
            _service.Update(instrument);
            return Ok(instrument);
        }

        [HttpDelete]
        public ActionResult<InstrumentDto> DeleteInstrument(InstrumentId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
