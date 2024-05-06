using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Portfolios.Domain;
using StockMarket.Features.Portfolios.Infrastructure;

namespace StockMarket.Features.Portfolios.Application;

public interface IPortfolioService
{
    void Create(PortfolioDto portfolioDto);
    Task<List<Portfolio>> GetAll();
    Task<Portfolio> Get(PortfolioId id);
    void Update(PortfolioDto portfolioDto);
    void Delete(PortfolioId id);
}

public class PortfolioService : IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly StockMarketAppDbContext _context;
    public PortfolioService()
    {
        _context = new StockMarketAppDbContext();
        _portfolioRepository = new PortfolioRepository(_context);
    }
    
    public void Create(PortfolioDto portfolioDto)
    {
        var portfolio = new Portfolio(
            new PortfolioId(Guid.NewGuid()),
            portfolioDto.TraderId,
            portfolioDto.InstrumentId,
            portfolioDto.Amount
            );
        _portfolioRepository.Create(portfolio);
    }

    public Task<List<Portfolio>> GetAll()
    {
        var portfolios = _portfolioRepository.GetAll();
        return portfolios;
    }

    public Task<Portfolio> Get(PortfolioId id)
    {
        return _portfolioRepository.Get(id);
    }

    public void Update(PortfolioDto portfolioDto)
    {
        var portfolio = new Portfolio(
            portfolioDto.Id,
            portfolioDto.TraderId,
            portfolioDto.InstrumentId,
            portfolioDto.Amount
            );
        _portfolioRepository.Update(portfolio);
    }

   public void Delete(PortfolioId id)
    {
        _portfolioRepository.Delete(id);
    }
}
