using Microsoft.EntityFrameworkCore;
using StockMarket.Features.Users.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.Users.Infrastructure
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly StockMarketAppDbContext _stockMarketDbContext;
        public UserRepository(StockMarketAppDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task Create(User user)
        {
            _stockMarketDbContext.Users.Add(user);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _stockMarketDbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> Get(string email)
        {
            var user = await _stockMarketDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task Delete(UserId userId)
        {
            var user = await _stockMarketDbContext.Users.FindAsync(userId);
            _stockMarketDbContext.Users.Remove(user);
            await _stockMarketDbContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _stockMarketDbContext.Entry(user).State = EntityState.Modified;
            await _stockMarketDbContext.SaveChangesAsync();
        }
    }
}
