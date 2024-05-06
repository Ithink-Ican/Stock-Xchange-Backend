using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Currencies.Domain;
using StockMarket.Features.Currencies.Infrastructure;

namespace StockMarket.Features.Currencies.Application;

public interface ICurrencyService
{
    void Create(CurrencyDto currencyDto);
    Task<List<Currency>> GetAll();
    Task<Currency> Get(CurrencyId id);
    void Update(CurrencyDto currencyDto);
    void Delete(CurrencyId id);
}
public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyRepository _currencyRepository;
    private readonly StockMarketAppDbContext _context;
    public CurrencyService()
    {
        _context = new StockMarketAppDbContext();
        _currencyRepository = new CurrencyRepository(_context);
    }

    public void Create(CurrencyDto currencyDto)
    {
        var Currency = new Currency(
            new CurrencyId(
                Guid.NewGuid()),
                currencyDto.IntCode,
                currencyDto.ChrCode,
                currencyDto.Amount,
                currencyDto.Name,
                currencyDto.Rate
                );
        _currencyRepository.Create(Currency);
    }

    public Task<List<Currency>> GetAll()
    {
        var Currencys = _currencyRepository.GetAll();
        return Currencys;
    }

    public Task<Currency> Get(CurrencyId id)
    {
        return _currencyRepository.Get(id);
    }

    public void Update(CurrencyDto currencyDto)
    {
        var Currency = new Currency(
            currencyDto.Id,
            currencyDto.IntCode,
            currencyDto.ChrCode,
            currencyDto.Amount,
            currencyDto.Name,
            currencyDto.Rate
            );
        _currencyRepository.Update(Currency);
    }

    public void Delete(CurrencyId id)
    {
        _currencyRepository.Delete(id);
    }
}
