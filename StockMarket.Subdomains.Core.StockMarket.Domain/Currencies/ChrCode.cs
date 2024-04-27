namespace Core.StockMarket.Domain.Currencies;

public record ChrCode
{
    private ChrCode(string value) => Value = value;
    public string Value { get; init; }
    public static ChrCode? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value.Length > 3)
        {
            return null;
        }

        return new ChrCode(value);
    }
}
