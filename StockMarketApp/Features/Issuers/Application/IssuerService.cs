using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockMarketApp.Features.Issuers.Domain;
using StockMarketApp.Features.Issuers.Infrastructure;

using StockMarketApp.Shared.Data;

namespace StockMarketApp.Features.Issuers.Application;

public class IssuerService
{
    private readonly IIssuerRepository _issuerRepository;

    public IssuerService(IIssuerRepository issuerRepository)
    {
        _issuerRepository = issuerRepository;
    }
    
    public void CreateIssuer(IssuerDto issuerDto)
    {
        var issuer = new Issuer(
            new IssuerId(Guid.NewGuid()),
            issuerDto.Name,
            issuerDto.Description
            );
        _issuerRepository.Create(issuer);
    }

    public IEnumerable<Issuer> GetAll()
    {
        
        return (IEnumerable<Issuer>)_issuerRepository.GetAll();
    }

    public Task<Issuer> Get(IssuerDto issuerDto)
    {
        return _issuerRepository.Get(issuerDto.Id);
    }

    public void Update(IssuerDto issuerDto)
    {
        var issuer = new Issuer(
            issuerDto.Id,
            issuerDto.Name,
            issuerDto.Description
            );
        _issuerRepository.Update(issuer);
    }
}
