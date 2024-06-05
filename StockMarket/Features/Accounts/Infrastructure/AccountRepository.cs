using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Shared.Infrastructure;
using StockMarket.Shared.Data;
using StockMarket.Features.Currencies.Domain;

namespace StockMarket.Features.Accounts.Infrastructure
{
    internal sealed class AccountRepository : IAccountRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public AccountRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(Account account)
        {
            var acc = await _stockMarketDbContext.Accounts.AnyAsync(
                a => a.TraderId == account.TraderId && a.CurrencyId == account.CurrencyId
                );
            if (!acc)
            {
                _stockMarketDbContext.Add(account);
                await _stockMarketDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Account>> GetAll()
        {
            var accounts = await _stockMarketDbContext.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<List<AccountDto>> GetByTrader(TraderId id)
        {/*
            var accounts = await _stockMarketDbContext.Accounts.Where(
                a => a.TraderId == id
                ).ToListAsync();
            return accounts; */
            var query = from a in _stockMarketDbContext.Accounts
                        .Where(a => a.TraderId == id)
                        from c in _stockMarketDbContext.Currencies
                        .Where(c => c.Id == a.CurrencyId)
                        select new AccountDto
                        {
                            Id = a.Id,
                            TraderId = id,
                            Balance = a.Balance,
                            CurrencyId = a.CurrencyId,
                            Currency = CurrencyDto.Create(
                                c.Id,
                                c.IntCode,
                                c.ChrCode,
                                c.Amount,
                                c.Name,
                                c.Rate
                            )
                        };
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<AccountDto> GetByTraderAndCurrency(TraderId id, CurrencyId currencyId)
        {
            var query = from c in _stockMarketDbContext.Currencies
                        .Where(c => c.Id == currencyId)
                        from a in _stockMarketDbContext.Accounts
                        .Where(a => a.TraderId == id && a.CurrencyId == c.Id)
                        select new AccountDto
                        {
                            Id = a.Id,
                            TraderId = id,
                            Balance = a.Balance,
                            CurrencyId = a.CurrencyId,
                            Currency = CurrencyDto.Create(
                                c.Id,
                                c.IntCode,
                                c.ChrCode,
                                c.Amount,
                                c.Name,
                                c.Rate
                            )
                        };
            if (query.Any())
            {
                return await query.FirstAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<Account> Get(AccountId accountId)
        {
            var account = await _stockMarketDbContext.Accounts.FindAsync(accountId);
            return account;
        }

        public async Task Delete(AccountId accountId)
        {
            var account = await _stockMarketDbContext.Accounts.FindAsync(accountId);
            _stockMarketDbContext.Accounts.Remove(account);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(Account account)
        {
            _stockMarketDbContext.Entry(account).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
