using StockMarket.Features.Currencies.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Accounts.Domain
{
    public interface IAccountRepository
    {
        Task Create(Account account);
        Task<List<Account>> GetAll();
        Task<Account> Get(AccountId id);
        Task<List<AccountDto>> GetByTrader(TraderId id);
        Task<AccountDto> GetByTraderAndCurrency(TraderId id, CurrencyId currencyId);
        Task Update(Account account);
        Task Delete(AccountId accountId);
    }
}
