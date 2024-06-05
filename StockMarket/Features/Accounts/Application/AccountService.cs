using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Accounts.Infrastructure;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Currencies.Domain;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Accounts.Application;

public interface IAccountService
{
    void Create(NewAccountDto AccountDto);
    Task<List<Account>> GetAll();
    Task<List<AccountDto>> GetByTrader(TraderId id);
    AccountDto GetByTraderAndCurrency(TraderId id, Guid currencyId);
    Task<Account> Get(AccountId id);
    void Update(AccountDto AccountDto);
    Task IncreaseBalance(AccountId id, decimal amount);
    Task DecreaseBalance(AccountId id, decimal amount);
    void Delete(AccountId id);
}

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly StockMarketAppDbContext _context;
    public AccountService()
    {
        _context = new StockMarketAppDbContext();
        _accountRepository = new AccountRepository(_context);
    }

    public async void Create(NewAccountDto accountDto)
    {
        var account = new Account(
            new AccountId(Guid.NewGuid()),
            accountDto.TraderId,
            accountDto.Balance,
            accountDto.CurrencyId
            );
        await _accountRepository.Create(account);
    }

    public Task<List<Account>> GetAll()
    {
        var accounts = _accountRepository.GetAll();
        return accounts;
    }

    public Task<List<AccountDto>> GetByTrader(TraderId id)
    {
        var accounts = _accountRepository.GetByTrader(id);
        return accounts;
    }

    public AccountDto GetByTraderAndCurrency(TraderId id, Guid currencyId)
    {
        var currId = new CurrencyId(currencyId);
        var account = _accountRepository.GetByTraderAndCurrency(id, currId).Result;
        return account;
    }
    public Task<Account> Get(AccountId id)
    {
        return _accountRepository.Get(id);
    }

    public void Update(AccountDto accountDto)
    {
        var account = new Account(
            accountDto.Id,
            accountDto.TraderId,
            accountDto.Balance,
            accountDto.CurrencyId
            );
        _accountRepository.Update(account);
    }

    public async Task IncreaseBalance(AccountId id, decimal amount)
    {
        var account = await Get(id);
        account.IncreaseBalance(amount);
        await _accountRepository.Update(account);
    }

    public async Task DecreaseBalance(AccountId id, decimal amount)
    {
        var account = await Get(id);
        account.DecreaseBalance(amount);
        await _accountRepository.Update(account);
    }

    public void Delete(AccountId id)
    {
        _accountRepository.Delete(id);
    }
}
