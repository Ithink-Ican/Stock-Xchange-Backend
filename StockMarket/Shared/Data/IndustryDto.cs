using StockMarket.Features.Industries.Domain;

namespace StockMarket.Shared.Data;

public class IndustryDto
{
    public IndustryId Id { get; set; }
    public string Name { get; set; }

    public IndustryDto()
    {
    }

    public static IndustryDto Create(
        IndustryId id,
        string name
        )
    {
        var dto = new IndustryDto();
        dto.Id = id;
        dto.Name = name;

        return dto;
    }

    public List<IndustryDto> BulkConvert(IEnumerable<Industry> industries)
    {
        var list = new List<IndustryDto>();
        foreach (var industry in industries)
        {
            var dto = IndustryDto.Create(
                industry.Id,
                industry.Name
            );
            list.Add(dto);
        }
        return list;
    }
}