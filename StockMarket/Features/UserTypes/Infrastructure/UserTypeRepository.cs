using Microsoft.EntityFrameworkCore;
using StockMarket.Features.UserTypes.Domain;
using StockMarket.Shared.Infrastructure;

namespace StockMarket.Features.UserTypes.Infrastructure;
public class UserTypeRepository : IUserTypeRepository
{
    private readonly StockMarketAppDbContext _stockMarketDbContext;
    public UserTypeRepository(StockMarketAppDbContext stockMarketDbContext)
    {
        _stockMarketDbContext = stockMarketDbContext;
    }
    public async Task Create(UserType userType)
    {
        _stockMarketDbContext.Add(userType);
        await _stockMarketDbContext.SaveChangesAsync();
    }

    public async Task<UserType> Get(UserTypeId userTypeId)
    {
        var userType = await _stockMarketDbContext.UserTypes.FindAsync(userTypeId);
        return userType;
    }

    public async Task<List<UserType>> GetAll()
    {
        var userTypes = await _stockMarketDbContext.UserTypes.ToListAsync();
        return userTypes;
    }

    public async Task Update(UserType userType)
    {
        _stockMarketDbContext.Entry(userType).State = EntityState.Modified;
        await _stockMarketDbContext.SaveChangesAsync();
    }

    public async Task Delete(UserTypeId userTypeId)
    {
        var userType = await _stockMarketDbContext.UserTypes.FindAsync(userTypeId);
        _stockMarketDbContext.UserTypes.Remove(userType);
        await _stockMarketDbContext.SaveChangesAsync();
    }
}