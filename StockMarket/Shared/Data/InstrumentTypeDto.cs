using StockMarket.Features.InstrumentTypes.Domain;

namespace StockMarket.Shared.Data;

public class InstrumentTypeDto
{
    public InstrumentTypeId Id { get; set; }
    public string Name { get; set; }

    public InstrumentTypeDto()
    {
    }

    public static InstrumentTypeDto Create(
        InstrumentTypeId id,
        string name
        )
    {
        var dto = new InstrumentTypeDto();
        dto.Id = id;
        dto.Name = name;

        return dto;
    }

    public List<InstrumentTypeDto> BulkConvert(IEnumerable<InstrumentType> instrumentTypes)
    {
        var list = new List<InstrumentTypeDto>();
        foreach (var instrumentType in instrumentTypes)
        {
            var dto = InstrumentTypeDto.Create(
                instrumentType.Id,
                instrumentType.Name
            );
            list.Add(dto);
        }
        return list;
    }
}