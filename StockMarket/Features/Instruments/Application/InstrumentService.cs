using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.Instruments.Infrastructure;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.InstrumentTypes.Domain;

namespace StockMarket.Features.Instruments.Application;

public interface IInstrumentService
{
    void Create(InstrumentDto instrumentDto);
    Task<List<Instrument>> GetAll();
    InstrumentDto Get(InstrumentId id);
    InstrumentDto GetByCode(string code);
    List<InstrumentDto> GetByType(InstrumentTypeId typeId);
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
            instrumentDto.IssuerName,
            instrumentDto.Description,
            instrumentDto.MarketPrice,
            instrumentDto.CurrencyId,
            instrumentDto.IsActive
            );
        _instrumentRepository.Create(instrument);
    }

    public Task<List<Instrument>> GetAll()
    {
        var instruments = _instrumentRepository.GetAll();
        return instruments;
    }

    public InstrumentDto Get(InstrumentId id)
    {
        var instrument = _instrumentRepository.Get(id).Result;
        var instrumentDto = InstrumentDto.Create(
            instrument.Id,
            instrument.Code,
            instrument.InstrumentTypeId,
            instrument.IndustryId,
            instrument.IssuerName,
            instrument.Description,
            instrument.MarketPrice,
            instrument.CurrencyId,
            instrument.IsActive
            );
        return instrumentDto;
    }

    public InstrumentDto GetByCode(string code)
    {
        var insCode = Code.Create(code);
        var instrument = _instrumentRepository.GetByCode(insCode).Result;
        var dto = InstrumentDto.Create(
            instrument.Id,
            instrument.Code,
            instrument.InstrumentTypeId,
            instrument.IndustryId,
            instrument.IssuerName,
            instrument.Description,
            instrument.MarketPrice,
            instrument.CurrencyId,
            instrument.IsActive
            );
        return dto;
    }

    public List<InstrumentDto> GetByType(InstrumentTypeId typeId)
    {
        var instruments = _instrumentRepository.GetByType(typeId).Result;
        var dto = new InstrumentDto();
        var dtos = dto.BulkConvert(instruments);
        return dtos;
    }

    public void Update(InstrumentDto instrumentDto)
    {
        var instrument = new Instrument(
            instrumentDto.Id,
            instrumentDto.Code,
            instrumentDto.InstrumentTypeId,
            instrumentDto.IndustryId,
            instrumentDto.IssuerName,
            instrumentDto.Description,
            instrumentDto.MarketPrice,
            instrumentDto.CurrencyId,
            instrumentDto.IsActive
            );
        _instrumentRepository.Update(instrument);
    }

   public void Delete(InstrumentId id)
    {
        _instrumentRepository.Delete(id);
    }
}
