using Microsoft.EntityFrameworkCore;
using StockMarketApp.Features.Issuers.Domain;
using StockMarketApp.Shared.Infrastructure;
using System.Threading.Tasks;

namespace StockMarketApp.Features.Issuers.Infrastructure
{
    internal sealed class IssuerRepository : IIssuerRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public IssuerRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Issuer issuer)
        {
            _stockMarketDbContext.Add(issuer);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Issuer>> GetAll()
        {
            var issuers = await _stockMarketDbContext.Issuers.ToListAsync();
            return issuers;
        }

        public async Task<Issuer> Get(IssuerId issuerId)
        {
            var issuer = await _stockMarketDbContext.Issuers.FindAsync(issuerId);
            return issuer;
        }

        public async Task Delete(IssuerId issuerId)
        {
            var issuer = await _stockMarketDbContext.Issuers.FindAsync(issuerId);
            _stockMarketDbContext.Issuers.Remove(issuer);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Issuer issuer)
        {
            _stockMarketDbContext.Entry(issuer).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
