using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Offers.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Offers.Infrastructure
{
    internal sealed class OfferRepository : IOfferRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public OfferRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Offer offer)
        {
            _stockMarketDbContext.Add(offer);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Offer>> GetAll()
        {
            var offers = await _stockMarketDbContext.Offers.ToListAsync();
            return offers;
        }

        public async Task<Offer> Get(OfferId offerId)
        {
            var offer = await _stockMarketDbContext.Offers.FindAsync(offerId);
            return offer;
        }

        public async Task Delete(OfferId offerId)
        {
            var offer = await _stockMarketDbContext.Offers.FindAsync(offerId);
            _stockMarketDbContext.Offers.Remove(offer);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Offer offer)
        {
            _stockMarketDbContext.Entry(offer).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Offer>> GetOfferByTraderId(TraderId id)
        {
            var offers = await _stockMarketDbContext.Offers.Where(
                o => o.TraderId == id
                ).ToListAsync();
            return offers;
        }

        public async Task<List<Offer>> GetLastFiveSatisfiedByTraderId(TraderId id)
        {
            var offers = await _stockMarketDbContext.Offers
                .Where(
                    o => o.TraderId == id && o.IsSatisfied == true
                )
                .Take(5)
                .OrderByDescending(
                    o => o.PlacementDate
                )
                .ToListAsync();
            return offers;
        }

        public async Task<List<Offer>> GetLastFiveUnsatisfiedByTraderId(TraderId id)
        {
            var offers = await _stockMarketDbContext.Offers
                .Where(
                    o => o.TraderId == id && o.IsSatisfied == false
                )
                .Take(5)
                .OrderByDescending(
                    o => o.PlacementDate
                )
                .ToListAsync();
            return offers;
        }
    }
}
