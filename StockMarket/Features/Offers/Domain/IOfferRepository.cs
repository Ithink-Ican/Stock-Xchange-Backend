using StockMarket.Features.Traders.Domain;
using System.Threading.Tasks;

namespace StockMarket.Features.Offers.Domain;
public interface IOfferRepository
{
    Task Create(Offer offer);
    Task<List<Offer>> GetAll();
    Task<Offer> Get(OfferId id);
    Task Update(Offer offer);
    Task Delete(OfferId offerId);
    Task<List<Offer>> GetOfferByTraderId(TraderId id);
    Task<List<Offer>> GetLastFiveUnsatisfiedByTraderId(TraderId id);
    Task<List<Offer>> GetLastFiveSatisfiedByTraderId(TraderId id);
}