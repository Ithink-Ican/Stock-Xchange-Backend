using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Users.Domain;
using StockMarket.Features.Users.Infrastructure;

namespace StockMarket.Features.Users.Application;

public interface IUserService
{
    void Create(UserDto userDto);
    Task<List<User>> GetAll();
    Task<User> Get(UserId id);
    void Update(UserDto userDto);
    void Delete(UserId id);
    bool Login(UserId id, string password);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly StockMarketAppDbContext _context;
    public UserService()
    {
        _context = new StockMarketAppDbContext();
        _userRepository = new UserRepository(_context);
    }
    
    public void Create(UserDto userDto)
    {
        var user = new User(
            new UserId(Guid.NewGuid()),
            userDto.Login,
            userDto.Password,
            userDto.Email,
            userDto.Name,
            userDto.UserTypeId
            );
        _userRepository.Create(user);
    }

    public Task<List<User>> GetAll()
    {
        var users = _userRepository.GetAll();
        return users;
    }

    public Task<User> Get(UserId id)
    {
        return _userRepository.Get(id);
    }

    public void Update(UserDto userDto)
    {
        var user = new User(
            userDto.Id,
            userDto.Login,
            userDto.Password,
            userDto.Email,
            userDto.Name,
            userDto.UserTypeId
            );
        _userRepository.Update(user);
    }

   public void Delete(UserId id)
    {
        _userRepository.Delete(id);
    }

    public bool Login(UserId id, string password)
    {
        var user = _userRepository.Get(id).Result;
        return user.ValidatePassword(password, user.Password, user.Salt);
    }
}
