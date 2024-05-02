using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketApp.Features.Issuers.Application;
using StockMarketApp.Features.Issuers.Infrastructure;
using StockMarketApp.Shared.Infrastructure;
using StockMarketApp.Shared.Data;

namespace StockMarketApp.Features.Issuers.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class IssuerController : ControllerBase
    {
        private StockMarketAppDbContext _context = new StockMarketAppDbContext();

        [HttpPost]
        public IssuerDto PostIssuer(IssuerDto issuerDto)
        {
            var issuerRepository = new IssuerRepository(_context);
            IssuerService issuerService = new IssuerService(issuerRepository);
            issuerService.Create(issuerDto);
            return issuerDto;
        }

        [HttpGet]
        public IEnumerable<IssuerDto> GetIssuers()
        {
            var issuerRepository = new IssuerRepository(_context);
            IssuerService issuerService = new IssuerService(issuerRepository);
            var dto = new IssuerDto();
            var issuers = issuerService.GetAll().Result;
            var dtos = dto.BulkConvert(issuers);
            return dtos;
        }

        public IssuerDto GetIssuer(IssuerDto issuerDto)
        {
            var issuerRepository = new IssuerRepository(_context);
            IssuerService issuerService = new IssuerService(issuerRepository);
            var issuer = issuerService.Get(issuerDto);
            var dto = IssuerDto.Create();
        }
    }
}
