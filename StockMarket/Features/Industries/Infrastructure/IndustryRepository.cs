using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Industries.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Industries.Infrastructure
{
    internal sealed class IndustryRepository : IIndustryRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public IndustryRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Industry issuer)
        {
            _stockMarketDbContext.Add(issuer);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Industry>> GetAll()
        {
            var issuers = await _stockMarketDbContext.Industries.ToListAsync();
            return issuers;
        }

        public async Task<Industry> Get(IndustryId issuerId)
        {
            var issuer = await _stockMarketDbContext.Industries.FindAsync(issuerId);
            return issuer;
        }

        public async Task Delete(IndustryId issuerId)
        {
            var issuer = await _stockMarketDbContext.Industries.FindAsync(issuerId);
            _stockMarketDbContext.Industries.Remove(issuer);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Industry issuer)
        {
            _stockMarketDbContext.Entry(issuer).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
