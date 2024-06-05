using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Industries.Domain;
using StockMarket.Features.Industries.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Industries.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class IndustryController : ControllerBase
    {
        private IIndustryService _service;

        public IndustryController()
        {
            _service = new IndustryService();
        }

        [HttpPost]
        public ActionResult<IndustryDto> PostIndustry(IndustryDto industryDto)
        {
            _service.Create(industryDto);
            return industryDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IndustryDto>> GetIndustries()
        {
            var dto = new IndustryDto();
            var industrys = _service.GetAll().Result;
            var dtos = dto.BulkConvert(industrys);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IndustryDto> GetIndustry(IndustryId id)
        {
            var industry = _service.Get(id).Result;
            var dto = IndustryDto.Create(industry.Id, industry.Name);
            return Ok(dto);
        }

        [HttpPut]
        public ActionResult<IndustryDto> PutIndustry(IndustryDto industry)
        {
            _service.Update(industry);
            return Ok(industry);
        }

        [HttpDelete]
        public ActionResult<IndustryDto> DeleteIndustry([FromQuery] IndustryId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
