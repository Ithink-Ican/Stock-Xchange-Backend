namespace StockMarket.Features.UserTypes.Domain
{
    public interface IUserTypeRepository
    {
        Task Create(UserType userType);
        Task<List<UserType>> GetAll();
        Task<UserType> Get(UserTypeId id);
        Task Update(UserType userType);
        Task Delete(UserTypeId userTypeId);
    }
}
