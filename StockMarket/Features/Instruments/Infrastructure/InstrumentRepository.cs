using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Instruments.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Instruments.Infrastructure
{
    internal sealed class InstrumentRepository : IInstrumentRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public InstrumentRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Instrument instrument)
        {
            _stockMarketDbContext.Add(instrument);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Instrument>> GetAll()
        {
            var instruments = await _stockMarketDbContext.Instruments.ToListAsync();
            return instruments;
        }

        public async Task<Instrument> Get(InstrumentId instrumentId)
        {
            var instrument = await _stockMarketDbContext.Instruments.FindAsync(instrumentId);
            return instrument;
        }

        public async Task Delete(InstrumentId instrumentId)
        {
            var instrument = await _stockMarketDbContext.Instruments.FindAsync(instrumentId);
            _stockMarketDbContext.Instruments.Remove(instrument);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Instrument instrument)
        {
            _stockMarketDbContext.Entry(instrument).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
