using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Offers.Domain;
using StockMarket.Features.Deals.Domain;
using StockMarket.Features.Deals.Infrastructure;

namespace StockMarket.Features.Deals.Application;

public interface IDealService
{
    void Create(DealDto dealDto);
    Task<List<Deal>> GetAll();
    Task<Deal> Get(DealId id);
    void Update(DealDto dealDto);
    void Delete(DealId id);
}
public class DealService : IDealService
{
    private readonly IDealRepository _dealRepository;
    private readonly StockMarketAppDbContext _context;
    public DealService()
    {
        _context = new StockMarketAppDbContext();
        _dealRepository = new DealRepository(_context);
    }

    public void Create(DealDto dealDto)
    {
        var deal = Deal.Create(
            dealDto.Id,
            dealDto.SellOfferId,
            dealDto.BuyOfferId
            );
            
        _dealRepository.Create(deal);
    }

    public Task<List<Deal>> GetAll()
    {
        var deals = _dealRepository.GetAll();
        return deals;
    }

    public Task<Deal> Get(DealId id)
    {
        return _dealRepository.Get(id);
    }

    public void Update(DealDto dealDto)
    {
        var deal = Deal.Create(
            dealDto.Id,
            dealDto.SellOfferId,
            dealDto.BuyOfferId
            );
        _dealRepository.Update(deal);
    }

    public void Delete(DealId id)
    {
        _dealRepository.Delete(id);
    }
}
