namespace StockMarket.Features.Currencies.Domain;

public interface ICurrencyRepository
{
    Task Create(Currency currency);
    Task<List<Currency>> GetAll();
    Task<Currency> Get(CurrencyId id);
    Task Update(Currency currency);
    Task Delete(CurrencyId currencyId);
}
