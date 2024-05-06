using System.Threading.Tasks;

namespace StockMarket.Features.Portfolios.Domain;
public interface IPortfolioRepository
{
    Task Create(Portfolio portfolio);
    Task<List<Portfolio>> GetAll();
    Task<Portfolio> Get(PortfolioId id);
    Task Update(Portfolio portfolio);
    Task Delete(PortfolioId portfolioId);
}