using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Currencies.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Currencies.Infrastructure
{
    internal sealed class CurrencyRepository : ICurrencyRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public CurrencyRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Currency currency)
        {
            _stockMarketDbContext.Add(currency);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Currency>> GetAll()
        {
            var currencies = await _stockMarketDbContext.Currencies.ToListAsync();
            return currencies;
        }

        public async Task<Currency> Get(CurrencyId currencyId)
        {
            var currency = await _stockMarketDbContext.Currencies.FindAsync(currencyId);
            return currency;
        }

        public async Task Delete(CurrencyId currencyId)
        {
            var currency = await _stockMarketDbContext.Currencies.FindAsync(currencyId);
            _stockMarketDbContext.Currencies.Remove(currency);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Currency currency)
        {
            _stockMarketDbContext.Entry(currency).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
