using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Shared.Infrastructure;

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
            _stockMarketDbContext.Add(account);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAll()
        {
            var accounts = await _stockMarketDbContext.Accounts.ToListAsync();
            return accounts;
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
