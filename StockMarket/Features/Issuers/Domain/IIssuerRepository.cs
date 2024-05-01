using System.Threading.Tasks;

namespace StockMarketApp.Features.Issuers.Domain;
public interface IIssuerRepository
{
    Task Create(Issuer issuer);
    Task<List<Issuer>> GetAll();
    Task<Issuer> Get(IssuerId id);
    Task Update(Issuer issuer);
    Task Delete(IssuerId issuerId);
}