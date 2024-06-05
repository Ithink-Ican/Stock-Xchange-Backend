using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.Issuers.Domain;
using StockMarket.Features.Industries.Domain;
using StockMarket.Features.Currencies.Domain;

namespace StockMarket.Shared.Data;

public class InstrumentDto
{
    public InstrumentId Id { get; set; }
    public Code Code { get; set; }
    public InstrumentTypeId InstrumentTypeId { get; set; }
    public IndustryId IndustryId { get; set; }
    public string IssuerName { get; set; }
    public string Description { get; set; }
    public decimal MarketPrice { get; set; }
    public CurrencyId CurrencyId { get; set; }
    public bool IsActive { get; set; }
    public InstrumentDto()
    {
    }

    public static InstrumentDto Create(
            InstrumentId id,
            Code code,
            InstrumentTypeId instrumentTypeId,
            IndustryId industryId,
            string issuerName,
            string description,
            decimal marketPrice,
            CurrencyId currencyId,
            bool isActive
        )
    {
        var dto = new InstrumentDto();
        dto.Id = id;
        dto.Code = code;
        dto.InstrumentTypeId = instrumentTypeId;
        dto.IndustryId = industryId;
        dto.IssuerName = issuerName;
        dto.Description = description;
        dto.MarketPrice = marketPrice;
        dto.CurrencyId = currencyId;
        dto.IsActive = isActive;

        return dto;
    }

    public List<InstrumentDto> BulkConvert(IEnumerable<Instrument> instruments)
    {
        var list = new List<InstrumentDto>();
        foreach (var instrument in instruments)
        {
            var dto = InstrumentDto.Create(
            instrument.Id,
            instrument.Code,
            instrument.InstrumentTypeId,
            instrument.IndustryId,
            instrument.IssuerName,
            instrument.Description,
            instrument.MarketPrice,
            instrument.CurrencyId,
            instrument.IsActive
            );
            list.Add(dto);
        }
        return list;
    }
}