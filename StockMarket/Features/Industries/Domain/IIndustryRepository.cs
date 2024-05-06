namespace StockMarket.Features.Industries.Domain;

public interface IIndustryRepository
{
    Task Create(Industry industry);
    Task<List<Industry>> GetAll();
    Task<Industry> Get(IndustryId id);
    Task Update(Industry industry);
    Task Delete(IndustryId industryId);
}
