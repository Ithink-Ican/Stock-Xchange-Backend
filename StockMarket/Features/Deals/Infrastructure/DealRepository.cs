using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Deals.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Deals.Infrastructure
{
    internal sealed class DealRepository : IDealRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public DealRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Deal deal)
        {
            _stockMarketDbContext.Add(deal);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Deal>> GetAll()
        {
            var deals = await _stockMarketDbContext.Deals.ToListAsync();
            return deals;
        }

        public async Task<Deal> Get(DealId dealId)
        {
            var deal = await _stockMarketDbContext.Deals.FindAsync(dealId);
            return deal;
        }

        public async Task Delete(DealId dealId)
        {
            var deal = await _stockMarketDbContext.Deals.FindAsync(dealId);
            _stockMarketDbContext.Deals.Remove(deal);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Deal deal)
        {
            _stockMarketDbContext.Entry(deal).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
