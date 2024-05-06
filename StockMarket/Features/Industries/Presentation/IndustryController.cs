using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Issuers.Domain;
using StockMarket.Features.Issuers.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Issuers.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class IssuerController : ControllerBase
    {
        private IIssuerService _service;

        public IssuerController()
        {
            _service = new IssuerService();
        }

        [HttpPost]
        public ActionResult<IssuerDto> PostIssuer(IssuerDto issuerDto)
        {
            _service.Create(issuerDto);
            return issuerDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IssuerDto>> GetIssuers()
        {
            var dto = new IssuerDto();
            var issuers = _service.GetAll().Result;
            var dtos = dto.BulkConvert(issuers);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IssuerDto> GetIssuer(IssuerId id)
        {
            var issuer = _service.Get(id).Result;
            var dto = IssuerDto.Create(issuer.Id, issuer.Name, issuer.Description);
            return Ok(dto);
        }

        [HttpPut]
        public ActionResult<IssuerDto> PutIssuer(IssuerDto issuer)
        {
            _service.Update(issuer);
            return Ok(issuer);
        }

        [HttpDelete]
        public ActionResult<IssuerDto> DeleteIssuer(IssuerId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
