using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Users.Domain;

namespace StockMarket.Shared.Data;

public class TraderDto
{
    public TraderId Id { get; set; }
    public string Name { get; set; }
    public string INN { get; set; }
    public UserId UserId { get; set; }

    public TraderDto()
    {
    }

    public static TraderDto Create(
        TraderId id,
        string name,
        INN inn,
        UserId userId
        )
    {
        var dto = new TraderDto();
        dto.Id = id;
        dto.Name = name;
        dto.INN = inn.Value;
        dto.UserId = userId;

        return dto;
    }

    public List<TraderDto> BulkConvert(IEnumerable<Trader> traders)
    {
        var list = new List<TraderDto>();
        foreach (var trader in traders)
        {
            var dto = TraderDto.Create(
                trader.Id,
                trader.Name,
                trader.INN,
                trader.UserId
            );
            list.Add(dto);
        }
        return list;
    }
}