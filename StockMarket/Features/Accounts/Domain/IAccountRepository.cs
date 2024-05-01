using StockMarketApp.Features.Accounts.Domain;

namespace StockMarketApp.Features.Accounts.Domain
{
    public interface IAccountRepository
    {
        void Create(Account account);
        IQueryable<Account> GetAll();
        void Update(Account account);
        void Delete(Account account);
    }
}
