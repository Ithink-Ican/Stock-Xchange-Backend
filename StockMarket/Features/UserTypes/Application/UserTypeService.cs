using StockMarket.Shared.Data;
using StockMarket.Shared.Infrastructure;
using StockMarket.Features.UserTypes.Domain;
using StockMarket.Features.UserTypes.Infrastructure;

namespace StockMarket.Features.UserTypes.Application;

public interface IUserTypeService
{
    void Create(UserTypeDto userTypeDto);
    Task<List<UserType>> GetAll();
    Task<UserType> Get(UserTypeId id);
    void Update(UserTypeDto userTypeDto);
    void Delete(UserTypeId id);
}
public class UserTypeService : IUserTypeService
{
    private readonly IUserTypeRepository _userTypeRepository;
    private readonly StockMarketAppDbContext _context;
    public UserTypeService()
    {
        _context = new StockMarketAppDbContext();
        _userTypeRepository = new UserTypeRepository(_context);
    }

    public void Create(UserTypeDto userTypeDto)
    {
        var userType = new UserType(
            new UserTypeId(
                Guid.NewGuid()),
                userTypeDto.Name
                );
        _userTypeRepository.Create(userType);
    }

    public Task<List<UserType>> GetAll()
    {
        var userTypes = _userTypeRepository.GetAll();
        return userTypes;
    }

    public Task<UserType> Get(UserTypeId id)
    {
        return _userTypeRepository.Get(id);
    }

    public void Update(UserTypeDto userTypeDto)
    {
        var userType = new UserType(
            userTypeDto.Id,
            userTypeDto.Name
            );
        _userTypeRepository.Update(userType);
    }

    public void Delete(UserTypeId id)
    {
        _userTypeRepository.Delete(id);
    }
}
