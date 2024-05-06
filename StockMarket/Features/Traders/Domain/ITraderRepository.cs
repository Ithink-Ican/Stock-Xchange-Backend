using System.Threading.Tasks;

namespace StockMarket.Features.Traders.Domain;
public interface ITraderRepository
{
    Task Create(Trader trader);
    Task<List<Trader>> GetAll();
    Task<Trader> Get(TraderId id);
    Task Update(Trader trader);
    Task Delete(TraderId traderId);
}