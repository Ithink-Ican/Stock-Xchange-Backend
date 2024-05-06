using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Industries.Domain;
using StockMarket.Features.Industries.Infrastructure;

namespace StockMarket.Features.Industries.Application;

public interface IIndustryService
{
    void Create(IndustryDto industryDto);
    Task<List<Industry>> GetAll();
    Task<Industry> Get(IndustryId id);
    void Update(IndustryDto industryDto);
    void Delete(IndustryId id);
}

public class IndustryService : IIndustryService
{
    private readonly IIndustryRepository _industryRepository;
    private readonly StockMarketAppDbContext _context;
    public IndustryService()
    {
        _context = new StockMarketAppDbContext();
        _industryRepository = new IndustryRepository(_context);
    }
    
    public void Create(IndustryDto industryDto)
    {
        var industry = new Industry(
            new IndustryId(Guid.NewGuid()),
            industryDto.Name
            );
        _industryRepository.Create(industry);
    }

    public Task<List<Industry>> GetAll()
    {
        var industrys = _industryRepository.GetAll();
        return industrys;
    }

    public Task<Industry> Get(IndustryId id)
    {
        return _industryRepository.Get(id);
    }

    public void Update(IndustryDto industryDto)
    {
        var industry = new Industry(
            industryDto.Id,
            industryDto.Name
            );
        _industryRepository.Update(industry);
    }

   public void Delete(IndustryId id)
    {
        _industryRepository.Delete(id);
    }
}
