using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Users.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Traders.Infrastructure
{
    internal sealed class TraderRepository : ITraderRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public TraderRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Trader trader)
        {
            _stockMarketDbContext.Add(trader);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Trader>> GetAll()
        {
            var traders = await _stockMarketDbContext.Traders.ToListAsync();
            return traders;
        }

        public async Task<Trader> Get(TraderId traderId)
        {
            var trader = await _stockMarketDbContext.Traders.FindAsync(traderId);
            return trader;
        }

        public async Task<Trader> GetByUserId(UserId id)
        {
            var trader = await _stockMarketDbContext.Traders.FirstOrDefaultAsync(
                t => t.UserId == id
                );
            return trader;
        }

        public async Task Delete(TraderId traderId)
        {
            var trader = await _stockMarketDbContext.Traders.FindAsync(traderId);
            _stockMarketDbContext.Traders.Remove(trader);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Trader trader)
        {
            _stockMarketDbContext.Entry(trader).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
