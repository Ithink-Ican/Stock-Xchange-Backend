using StockMarketApp.Features.Issuers.Domain;

namespace StockMarketApp.Shared.Data;

public class IssuerDto
{
    public IssuerId Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public IssuerDto()
    {
    }

    public static IssuerDto Create(IssuerId id, string name, string description)
    {
        var dto = new IssuerDto();
        dto.Id = id;
        dto.Name = name;
        dto.Description = description;
        return dto;
    }

    public List<IssuerDto> BulkConvert(IEnumerable<Issuer> issuers)
    {
        var list = new List<IssuerDto>();
        foreach(var issuer in issuers)
        {
            var dto = IssuerDto.Create(issuer.Id, issuer.Name, issuer.Description);
            list.Add(dto);
        }
        return list;
    }
}
