using System.Threading.Tasks;

namespace StockMarket.Features.InstrumentTypes.Domain;
public interface IInstrumentTypeRepository
{
    Task Create(InstrumentType issuer);
    Task<List<InstrumentType>> GetAll();
    Task<InstrumentType> Get(InstrumentTypeId id);
    Task Update(InstrumentType issuer);
    Task Delete(InstrumentTypeId issuerId);
}