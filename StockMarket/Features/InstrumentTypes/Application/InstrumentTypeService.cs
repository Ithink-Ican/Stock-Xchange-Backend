using StockMarket.Shared.Infrastructure;
using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.InstrumentTypes.Infrastructure;
using StockMarket.Shared.Data;

namespace StockMarket.Features.InstrumentTypes.Application;

public interface IInstrumentTypeService
{
    void Create(InstrumentTypeDto InstrumentTypeDto);
    Task<List<InstrumentType>> GetAll();
    Task<InstrumentType> Get(InstrumentTypeId id);
    void Update(InstrumentTypeDto InstrumentTypeDto);
    void Delete(InstrumentTypeId id);
}

public class InstrumentTypeService : IInstrumentTypeService
{
    private readonly IInstrumentTypeRepository _instrumentTypeRepository;
    private readonly StockMarketAppDbContext _context;
    public InstrumentTypeService()
    {
        _context = new StockMarketAppDbContext();
        _instrumentTypeRepository = new InstrumentTypeRepository(_context);
    }

    public void Create(InstrumentTypeDto instrumentTypeDto)
    {
        var instrumentType = new InstrumentType(
            new InstrumentTypeId(Guid.NewGuid()),
                instrumentTypeDto.Name
            );
        _instrumentTypeRepository.Create(instrumentType);
    }

    public Task<List<InstrumentType>> GetAll()
    {
        var instrumentTypes = _instrumentTypeRepository.GetAll();
        return instrumentTypes;
    }

    public Task<InstrumentType> Get(InstrumentTypeId id)
    {
        return _instrumentTypeRepository.Get(id);
    }

    public void Update(InstrumentTypeDto instrumentTypeDto)
    {
        var instrumentType = new InstrumentType(
            new InstrumentTypeId(Guid.NewGuid()),
            instrumentTypeDto.Name
            );
        _instrumentTypeRepository.Update(instrumentType);
    }

    public void Delete(InstrumentTypeId id)
    {
        _instrumentTypeRepository.Delete(id);
    }
}
