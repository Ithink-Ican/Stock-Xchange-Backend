using System.Threading.Tasks;
using StockMarket.Features.Users.Domain;

namespace StockMarket.Features.Traders.Domain;
public interface ITraderRepository
{
    Task Create(Trader trader);
    Task<List<Trader>> GetAll();
    Task<Trader> Get(TraderId id);
    Task<Trader> GetByUserId(UserId id);
    Task Update(Trader trader);
    Task Delete(TraderId traderId);
}