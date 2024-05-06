namespace StockMarket.Features.Accounts.Domain
{
    public interface IAccountRepository
    {
        Task Create(Account account);
        Task<List<Account>> GetAll();
        Task<Account> Get(AccountId id);
        Task Update(Account account);
        Task Delete(AccountId accountId);
    }
}
