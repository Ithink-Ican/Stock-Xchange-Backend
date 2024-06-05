using StockMarket.Features.InstrumentTypes.Domain;
using System.Threading.Tasks;

namespace StockMarket.Features.Instruments.Domain;
public interface IInstrumentRepository
{
    Task Create(Instrument instrument);
    Task<List<Instrument>> GetAll();
    Task<Instrument> Get(InstrumentId id);
    Task<List<Instrument>> GetByType(InstrumentTypeId typeId);
    Task<Instrument> GetByCode(Code code);
    Task Update(Instrument instrument);
    Task Delete(InstrumentId instrumentId);
}