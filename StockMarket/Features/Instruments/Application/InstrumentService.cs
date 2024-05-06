using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.Instruments.Infrastructure;

namespace StockMarket.Features.Instruments.Application;

public interface IInstrumentService
{
    void Create(InstrumentDto instrumentDto);
    Task<List<Instrument>> GetAll();
    Task<Instrument> Get(InstrumentId id);
    void Update(InstrumentDto instrumentDto);
    void Delete(InstrumentId id);
}

public class InstrumentService : IInstrumentService
{
    private readonly IInstrumentRepository _instrumentRepository;
    private readonly StockMarketAppDbContext _context;
    public InstrumentService()
    {
        _context = new StockMarketAppDbContext();
        _instrumentRepository = new InstrumentRepository(_context);
    }
    
    public void Create(InstrumentDto instrumentDto)
    {
        var instrument = new Instrument(
            new InstrumentId(Guid.NewGuid()),
            instrumentDto.Code,
            instrumentDto.InstrumentTypeId,
            instrumentDto.IndustryId,
            instrumentDto.IssuerId,
            instrumentDto.IsActive,
            instrumentDto.SubInstruments
            );
        _instrumentRepository.Create(instrument);
    }

    public Task<List<Instrument>> GetAll()
    {
        var instruments = _instrumentRepository.GetAll();
        return instruments;
    }

    public Task<Instrument> Get(InstrumentId id)
    {
        return _instrumentRepository.Get(id);
    }

    public void Update(InstrumentDto instrumentDto)
    {
        var instrument = new Instrument(
            instrumentDto.Id,
            instrumentDto.Code,
            instrumentDto.InstrumentTypeId,
            instrumentDto.IndustryId,
            instrumentDto.IssuerId,
            instrumentDto.IsActive,
            instrumentDto.SubInstruments
            );
        _instrumentRepository.Update(instrument);
    }

   public void Delete(InstrumentId id)
    {
        _instrumentRepository.Delete(id);
    }
}
