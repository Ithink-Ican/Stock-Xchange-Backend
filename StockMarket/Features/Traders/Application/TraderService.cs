using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Traders.Infrastructure;

namespace StockMarket.Features.Traders.Application;

public interface ITraderService
{
    void Create(TraderDto traderDto);
    Task<List<Trader>> GetAll();
    Task<Trader> Get(TraderId id);
    void Update(TraderDto traderDto);
    void Delete(TraderId id);
}

public class TraderService : ITraderService
{
    private readonly ITraderRepository _traderRepository;
    private readonly StockMarketAppDbContext _context;
    public TraderService()
    {
        _context = new StockMarketAppDbContext();
        _traderRepository = new TraderRepository(_context);
    }
    
    public void Create(TraderDto traderDto)
    {
        var trader = new Trader(
            new TraderId(Guid.NewGuid()),
            traderDto.Name,
            traderDto.INN,
            traderDto.UserId
            );
        _traderRepository.Create(trader);
    }

    public Task<List<Trader>> GetAll()
    {
        var traders = _traderRepository.GetAll();
        return traders;
    }

    public Task<Trader> Get(TraderId id)
    {
        return _traderRepository.Get(id);
    }

    public void Update(TraderDto traderDto)
    {
        var trader = new Trader(
            traderDto.Id,
            traderDto.Name,
            traderDto.INN,
            traderDto.UserId
            );
        _traderRepository.Update(trader);
    }

   public void Delete(TraderId id)
    {
        _traderRepository.Delete(id);
    }
}
