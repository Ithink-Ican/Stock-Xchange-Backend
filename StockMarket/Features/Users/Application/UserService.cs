using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.Users.Domain;
using StockMarket.Features.Users.Infrastructure;

namespace StockMarket.Features.Users.Application;

public interface IUserService
{
    void Create(NewUserDto userDto);
    Task<List<User>> GetAll();
    Task<User> Get(string email);
    void Update(UserDto userDto);
    void Delete(UserId id);
    string Login(string email, string password);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly StockMarketAppDbContext _context;
    private readonly PasswordEncryptor _passwordEncryptor;
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    public UserService()
    {
        _context = new StockMarketAppDbContext();
        _userRepository = new UserRepository(_context);
        _passwordEncryptor = new PasswordEncryptor();
        _jwtTokenGenerator = new JwtTokenGenerator();
    }
    
    public void Create(NewUserDto newUserDto)
    {
        var encryptionResult = _passwordEncryptor.EncryptPassword(newUserDto.Password);
        var user = new User(
            new UserId(Guid.NewGuid()), 
            newUserDto.Email,
            newUserDto.Name,
            encryptionResult["password"],
            encryptionResult["salt"]
            );
        _userRepository.Create(user);
    }

    public Task<List<User>> GetAll()
    {
        var users = _userRepository.GetAll();
        return users;
    }

    public Task<User> Get(string email)
    {
        return _userRepository.Get(email);
    }

    public void Update(UserDto userDto)
    {
        var user = new User(
            userDto.Id,
            userDto.Password,
            userDto.Salt,
            userDto.Email,
            userDto.Name
            );
        _userRepository.Update(user);
    }

   public void Delete(UserId id)
    {
        _userRepository.Delete(id);
    }

    public string Login(string email, string password)
    {
        var user = _userRepository.Get(email).Result;

        if (_passwordEncryptor.ValidatePassword(password, user.Password, user.Salt))
        {
            string token = _jwtTokenGenerator.Generate(user);
            return token;
        }
        return "";
    }
}
