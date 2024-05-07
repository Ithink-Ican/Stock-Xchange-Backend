using System.Threading.Tasks;

namespace StockMarket.Features.Users.Domain;
public interface IUserRepository
{
    Task Create(User user);
    Task<List<User>> GetAll();
    Task<User> Get(string email);
    Task Update(User user);
    Task Delete(UserId userId);
}