using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Issuers.Domain;
using StockMarket.Features.Issuers.Infrastructure;

namespace StockMarket.Features.Issuers.Application;

public interface IIssuerService
{
    void Create(IssuerDto issuerDto);
    Task<List<Issuer>> GetAll();
    Task<Issuer> Get(IssuerId id);
    void Update(IssuerDto issuerDto);
    void Delete(IssuerId id);
}

public class IssuerService : IIssuerService
{
    private readonly IIssuerRepository _issuerRepository;
    private readonly StockMarketAppDbContext _context;
    public IssuerService()
    {
        _context = new StockMarketAppDbContext();
        _issuerRepository = new IssuerRepository(_context);
    }
    
    public void Create(IssuerDto issuerDto)
    {
        var issuer = new Issuer(
            new IssuerId(Guid.NewGuid()),
            issuerDto.Name,
            issuerDto.Description
            );
        _issuerRepository.Create(issuer);
    }

    public Task<List<Issuer>> GetAll()
    {
        var issuers = _issuerRepository.GetAll();
        return issuers;
    }

    public Task<Issuer> Get(IssuerId id)
    {
        return _issuerRepository.Get(id);
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

   public void Delete(IssuerId id)
    {
        _issuerRepository.Delete(id);
    }
}
