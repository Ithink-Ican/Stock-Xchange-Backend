namespace StockMarketApp.Features.Currencies.Domain;

public record IntCode
{
    private IntCode(int value) => Value = value;
    public int Value { get; init; }
    private const int maxValue = 99;
    public static IntCode? Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException(
                "Значение должно быть больше нуля",
                nameof(value));
        }

        if (value % 100 > maxValue)
        {
            throw new ArgumentException(
                "Код не может быть больше 999",
                nameof(value));
        }

        return new IntCode(value);
    }
}
