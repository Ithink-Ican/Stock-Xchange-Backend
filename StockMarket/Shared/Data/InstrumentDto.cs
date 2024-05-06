using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.Issuers.Domain;
using StockMarket.Features.Industries.Domain;

namespace StockMarket.Shared.Data;

public class InstrumentDto
{
    public InstrumentId Id { get; set; }
    public Code Code { get; set; }
    public InstrumentTypeId InstrumentTypeId { get; set; }
    public IndustryId IndustryId { get; set; }
    public IssuerId IssuerId { get; set; }
    public bool IsActive { get; set; }
    public List<Instrument> SubInstruments { get; set; }


public InstrumentDto()
    {
    }

    public static InstrumentDto Create(
            InstrumentId id,
            Code code,
            InstrumentTypeId instrumentTypeId,
            IndustryId industryId,
            IssuerId issuerId,
            bool isActive,
            List<Instrument> subInstruments
        )
    {
        var dto = new InstrumentDto();
        dto.Id = id;
        dto.Code = code;
        dto.InstrumentTypeId = instrumentTypeId;
        dto.IndustryId = industryId;
        dto.IssuerId = issuerId;
        dto.IsActive = isActive;
        dto.SubInstruments = subInstruments;

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
            instrument.IssuerId,
            instrument.IsActive,
            instrument.SubInstruments
            );
            list.Add(dto);
        }
        return list;
    }
}