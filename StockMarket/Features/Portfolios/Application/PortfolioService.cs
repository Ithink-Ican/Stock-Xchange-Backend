using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Portfolios.Domain;
using StockMarket.Features.Portfolios.Infrastructure;
using StockMarket.Features.Traders.Domain;
using System.Collections.Generic;
using StockMarket.Features.Instruments.Domain;

namespace StockMarket.Features.Portfolios.Application;

public interface IPortfolioService
{
    void Create(PortfolioDto portfolioDto);
    Task<List<Portfolio>> GetAll();
    Task<Portfolio> Get(PortfolioId id);
    List<PortfolioDto> GetByTrader(TraderId id);
    PortfolioDto GetByTraderInstrument(Guid id, Guid instrumentId);
    List<PortfolioDto> GetTraderPortfolio(TraderId id);
    void Update(PortfolioDto portfolioDto);
    void Delete(PortfolioId id);
    void Buy(Portfolio portfolio);
    void Sell(PortfolioId id, int amount);
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

    public List<PortfolioDto> GetByTrader(TraderId id)
    {
        var portfolios =  _portfolioRepository.GetByTrader(id).Result;
        var dtos = new PortfolioDto().BulkConvert(portfolios);
        return dtos;
    }

    public List<PortfolioDto> GetTraderPortfolio(TraderId id)
    {
        var queryResult = _portfolioRepository.GetTraderPortfolio(id).Result;
        return queryResult;
    }

    public PortfolioDto GetByTraderInstrument(Guid id, Guid instrumentId)
    {
        var traderId = new TraderId(id);
        var instId = new InstrumentId(instrumentId);
        var portfolio = _portfolioRepository.GetByTraderInstrument(traderId, instId).Result;
        var dto = PortfolioDto.Create(
            portfolio.Id,
            portfolio.TraderId,
            portfolio.InstrumentId,
            portfolio.Amount
            );
        return dto;
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
    public async void Buy(Portfolio portfolio)
    {
        await _portfolioRepository.Buy(portfolio);
    }
    public async void Sell(PortfolioId id, int amount)
    {
        await _portfolioRepository.Sell(id, amount);
    }
}
