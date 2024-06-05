using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Offers.Domain;
using StockMarket.Features.Offers.Infrastructure;
using StockMarket.Features.Traders.Domain;

namespace StockMarket.Features.Offers.Application;

public interface IOfferService
{
    void Create(OfferDto offerDto);
    Task<List<Offer>> GetAll();
    Task<Offer> Get(OfferId id);
    void Update(OfferDto offerDto);
    void Delete(OfferId id);
    Task<List<Offer>> GetOfferByTraderId(TraderId id);
    Task<List<Offer>> GetLastFiveSatisfiedByTraderId(TraderId id);
    Task<List<Offer>> GetLastFiveUnsatisfiedByTraderId(TraderId id);
}

public class OfferService : IOfferService
{
    private readonly IOfferRepository _offerRepository;
    private readonly StockMarketAppDbContext _context;
    public OfferService()
    {
        _context = new StockMarketAppDbContext();
        _offerRepository = new OfferRepository(_context);
    }
    
    public void Create(OfferDto offerDto)
    {
        var offer = new Offer(
            new OfferId(Guid.NewGuid()),
            offerDto.TraderId,
            offerDto.InstrumentId,
            offerDto.Amount,
            offerDto.Price,
            offerDto.IsSale,
            offerDto.IsSatisfied
            );
        _offerRepository.Create(offer);
    }

    public Task<List<Offer>> GetAll()
    {
        var offers = _offerRepository.GetAll();
        return offers;
    }

    public Task<Offer> Get(OfferId id)
    {
        return _offerRepository.Get(id);
    }

    public Task<List<Offer>> GetOfferByTraderId(TraderId id)
    {
        var offers = _offerRepository.GetOfferByTraderId(id);
        return offers;
    }
    public Task<List<Offer>> GetLastFiveSatisfiedByTraderId(TraderId id)
    {
        var offers = _offerRepository.GetLastFiveSatisfiedByTraderId(id);
        return offers;
    }
    public Task<List<Offer>> GetLastFiveUnsatisfiedByTraderId(TraderId id)
    {
        var offers = _offerRepository.GetLastFiveUnsatisfiedByTraderId(id);
        return offers;
    }

    public void Update(OfferDto offerDto)
    {
        var offer = new Offer(
            offerDto.Id,
            offerDto.TraderId,
            offerDto.InstrumentId,
            offerDto.Amount,
            offerDto.Price,
            offerDto.IsSale,
            offerDto.IsSatisfied
            );
        _offerRepository.Update(offer);
    }

   public void Delete(OfferId id)
    {
        _offerRepository.Delete(id);
    }
}
