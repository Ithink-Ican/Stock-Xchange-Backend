using StockMarket.Features.Currencies.Domain;

namespace StockMarket.Shared.Data;

public class CurrencyDto
{
    public CurrencyId Id { get; set; }
    public IntCode IntCode { get; set; }
    public ChrCode ChrCode { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }
    public decimal Rate { get; set; }

    public CurrencyDto()
    {
    }

    public static CurrencyDto Create(
        CurrencyId id,
        IntCode intCode,
        ChrCode chrCode,
        int amount, string
        name,
        decimal rate
        )
    {
        var dto = new CurrencyDto();
        dto.Id = id;
        dto.IntCode = intCode;
        dto.ChrCode = chrCode;
        dto.Amount = amount;
        dto.Name = name;
        dto.Rate = rate;

        return dto;
    }

    public List<CurrencyDto> BulkConvert(IEnumerable<Currency> currencies)
    {
        var list = new List<CurrencyDto>();
        foreach (var currency in currencies)
        {
            var dto = CurrencyDto.Create(
                currency.Id,
                currency.IntCode,
                currency.ChrCode,
                currency.Amount,
                currency.Name,
                currency.Rate
            );
            list.Add(dto);
        }
        return list;
    }
}