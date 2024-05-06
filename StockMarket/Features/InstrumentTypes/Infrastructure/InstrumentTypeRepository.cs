using Microsoft.EntityFrameworkCore;
using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.InstrumentTypes.Infrastructure
{
    internal sealed class InstrumentTypeRepository : IInstrumentTypeRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public InstrumentTypeRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(InstrumentType instrumentType)
        {
            _stockMarketDbContext.Add(instrumentType);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<InstrumentType>> GetAll()
        {
            var instrumentTypes = await _stockMarketDbContext.InstrumentTypes.ToListAsync();
            return instrumentTypes;
        }

        public async Task<InstrumentType> Get(InstrumentTypeId instrumentTypeId)
        {
            var instrumentType = await _stockMarketDbContext.InstrumentTypes.FindAsync(instrumentTypeId);
            return instrumentType;
        }

        public async Task Delete(InstrumentTypeId instrumentTypeId)
        {
            var instrumentType = await _stockMarketDbContext.InstrumentTypes.FindAsync(instrumentTypeId);
            _stockMarketDbContext.InstrumentTypes.Remove(instrumentType);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(InstrumentType instrumentType)
        {
            _stockMarketDbContext.Entry(instrumentType).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
