using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Accounts.Infrastructure;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Accounts.Application;

public interface IAccountService
{
    void Create(AccountDto AccountDto);
    Task<List<Account>> GetAll();
    Task<Account> Get(AccountId id);
    void Update(AccountDto AccountDto);
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

    public void Create(AccountDto accountDto)
    {
        var account = new Account(
            new AccountId(Guid.NewGuid()),
            accountDto.TraderId,
            accountDto.Balance,
            accountDto.CurrencyId
            );
        _accountRepository.Create(account);
    }

    public Task<List<Account>> GetAll()
    {
        var accounts = _accountRepository.GetAll();
        return accounts;
    }

    public Task<Account> Get(AccountId id)
    {
        return _accountRepository.Get(id);
    }

    public void Update(AccountDto accountDto)
    {
        var account = new Account(
            new AccountId(Guid.NewGuid()),
            accountDto.TraderId,
            accountDto.Balance,
            accountDto.CurrencyId
            );
        _accountRepository.Update(account);
    }

    public void Delete(AccountId id)
    {
        _accountRepository.Delete(id);
    }
}
