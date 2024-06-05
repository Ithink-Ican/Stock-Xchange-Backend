using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Instruments.Domain;
using System.Threading.Tasks;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Portfolios.Domain;
public interface IPortfolioRepository
{
    Task Create(Portfolio portfolio);
    Task<List<Portfolio>> GetAll();
    Task<Portfolio> Get(PortfolioId id);
    Task<List<Portfolio>> GetByTrader(TraderId id);
    Task<List<PortfolioDto>> GetTraderPortfolio(TraderId id);
    Task<Portfolio> GetByTraderInstrument(TraderId id, InstrumentId instrumentId);
    Task Update(Portfolio portfolio);
    Task Delete(PortfolioId portfolioId);
    Task Buy(Portfolio portfolio);
    Task Sell(PortfolioId id, int amount);
}