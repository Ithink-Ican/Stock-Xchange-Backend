using StockMarket.Features.Deals.Domain;
using StockMarket.Features.Offers.Domain;

namespace StockMarket.Shared.Data;

public class DealDto
{
    public DealId Id { get; set; }
    public OfferId SellOfferId { get; set; }
    public OfferId BuyOfferId { get; set; }
    public DateTime DealDate { get; set; }

    public DealDto()
    {
    }

    public static DealDto Create(DealId id,
            OfferId sellOfferId,
            OfferId buyOfferId
        )
    {
        var dto = new DealDto();
        dto.Id = id;
        dto.SellOfferId = sellOfferId;
        dto.BuyOfferId = buyOfferId;
        return dto;
    }

    public List<DealDto> BulkConvert(IEnumerable<Deal> issuers)
    {
        var list = new List<DealDto>();
        foreach(var issuer in issuers)
        {
            var dto = DealDto.Create(
                issuer.Id,
                issuer.SellOfferId,
                issuer.BuyOfferId
                );
            list.Add(dto);
        }
        return list;
    }
}
