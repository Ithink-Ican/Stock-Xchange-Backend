using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Portfolios.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Instruments.Domain;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography;

namespace StockMarket.Features.Portfolios.Infrastructure
{
    internal sealed class PortfolioRepository : IPortfolioRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public PortfolioRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task<Portfolio> CheckIfExists(Portfolio portfolio)
        {
            var foundPortfolio = await _stockMarketDbContext.Portfolios.FindAsync(portfolio);
            return foundPortfolio;
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

        public async Task<List<Portfolio>> GetByTrader(TraderId id)
        {
            var portfolios = await _stockMarketDbContext.Portfolios
                .Where(p => p.TraderId == id)
                .ToListAsync();
            return portfolios;
        }

        public async Task<List<PortfolioDto>> GetTraderPortfolio(TraderId id)
        {
            var query = from p in _stockMarketDbContext.Portfolios
                        .Where(p => p.TraderId == id)
                        from i in _stockMarketDbContext.Instruments
                        .Where(i => i.Id == p.InstrumentId)
                        select new PortfolioDto
                        {
                            Id = p.Id,
                            TraderId = id,
                            InstrumentId = p.InstrumentId,
                            Amount = p.Amount,
                            Instrument = InstrumentDto.Create(
                                i.Id,
                                i.Code,
                                i.InstrumentTypeId,
                                i.IndustryId,
                                i.IssuerName,
                                i.Description,
                                i.MarketPrice,
                                i.CurrencyId,
                                i.IsActive
                                )
                        };
            var result = await query.ToListAsync();
            return result;
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


        public async Task<Portfolio> GetByTraderInstrument(TraderId id, InstrumentId instrumentId)
        {
            var portfolio = await _stockMarketDbContext.Portfolios.Where(
                p => p.TraderId == id && p.InstrumentId == instrumentId
                ).FirstAsync();
            return portfolio;
        }

        public async Task Buy(Portfolio portfolio)
        {
            var foundPortfolio = await _stockMarketDbContext.Portfolios.Where
                (
                   p => p.TraderId == portfolio.TraderId &&
                   p.InstrumentId == portfolio.InstrumentId
                ).AnyAsync();
            if (!foundPortfolio)
            {
                await Create(portfolio);
            }
            else
            {
                var exPortfolio = await _stockMarketDbContext.Portfolios.Where
                (
                   p => p.TraderId == portfolio.TraderId &&
                   p.InstrumentId == portfolio.InstrumentId
                ).FirstAsync();
                exPortfolio.IncreaseAmount(portfolio.Amount);
                await Update(exPortfolio);
            }
        }

        public async Task Sell(PortfolioId id, int amount)
        {
            var portfolio = await Get(id);
            if (portfolio != null)
            {
                if (portfolio.Amount - amount > 0)
                {                
                    portfolio.DecreaseAmount(amount);
                    await Update(portfolio);
                }
                else
                {
                    await Delete(id);
                }
            }
        }
    }
}
