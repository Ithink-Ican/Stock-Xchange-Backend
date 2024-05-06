using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Portfolios.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Portfolios.Infrastructure
{
    internal sealed class PortfolioRepository : IPortfolioRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public PortfolioRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Portfolio portfolio)
        {
            _stockMarketDbContext.Add(portfolio);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Portfolio>> GetAll()
        {
            var portfolios = await _stockMarketDbContext.Portfolios.ToListAsync();
            return portfolios;
        }

        public async Task<Portfolio> Get(PortfolioId portfolioId)
        {
            var portfolio = await _stockMarketDbContext.Portfolios.FindAsync(portfolioId);
            return portfolio;
        }

        public async Task Delete(PortfolioId portfolioId)
        {
            var portfolio = await _stockMarketDbContext.Portfolios.FindAsync(portfolioId);
            _stockMarketDbContext.Portfolios.Remove(portfolio);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Portfolio portfolio)
        {
            _stockMarketDbContext.Entry(portfolio).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
