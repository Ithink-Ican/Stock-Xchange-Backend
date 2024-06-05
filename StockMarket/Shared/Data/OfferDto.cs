using StockMarket.Features.Currencies.Domain;
using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Offers.Domain;

namespace StockMarket.Shared.Data;

public class OfferDto
{
    public OfferId Id { get; set; }
    public TraderId TraderId { get; set; }
    public InstrumentId InstrumentId { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public bool IsSale { get; set; }
    public bool IsSatisfied { get; set; }
    public DateTime? PlacementDate { get; set; }

    public OfferDto()
    {
    }

    public static OfferDto Create(
        OfferId id, 
        TraderId traderId, 
        InstrumentId instrumentId, 
        int amount, 
        decimal price, 
        bool isSale,
        bool isSatisfied,
        DateTime? placementDate
        )
    {
        var dto = new OfferDto();
        dto.Id = id;
        dto.TraderId = traderId;
        dto.InstrumentId = instrumentId;
        dto.Amount = amount;
        dto.Price = price;
        dto.IsSale = isSale;
        dto.IsSatisfied = isSatisfied;
        dto.PlacementDate = placementDate;

        return dto;
    }

    public List<OfferDto> BulkConvert(IEnumerable<Offer> offers)
    {
        var list = new List<OfferDto>();
        foreach (var offer in offers)
        {
            var dto = OfferDto.Create(
                offer.Id,
                offer.TraderId,
                offer.InstrumentId,
                offer.Amount,
                offer.Price,
                offer.IsSale,
                offer.IsSatisfied,
                offer.PlacementDate
            );
            list.Add(dto);
        }
        return list;
    }
}