namespace Core.StockMarket.Domain.Currencies;

public record IntCode
{
    private IntCode(int value) => Value = value;
    public int Value { get; init; }
    private const int maxValue = 99;
    public static IntCode? Create(int value)
    {
        if (value == 0)
        {
            return null;
        }

        if (value % 100 > maxValue)
        {
            return null;
        }

        return new IntCode(value);
    }
}
