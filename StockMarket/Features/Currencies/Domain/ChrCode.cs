namespace StockMarketApp.Features.Currencies.Domain;

public record ChrCode
{
    private ChrCode(string value) => Value = value;
    public string Value { get; init; }
    public static ChrCode? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException(
                "Буквенный код не может быть пустым",
                nameof(value));
        }

        if (value.Length > 3)
        {
            throw new ArgumentException(
                "Буквенный не может быть длиннее 3 символов",
                nameof(value));
        }

        return new ChrCode(value);
    }
}
