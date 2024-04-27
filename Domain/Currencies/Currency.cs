namespace Domain.Currencies;

public class Currency
{
    public Currency(CurrencyId id, int intCode, string chrCode, int amount, string name, decimal rate)
    {
        Id = id;
        IntCode = intCode;
        ChrCode = chrCode;
        Amount = amount;
        Name = name;
        Rate = rate;
    }

    public CurrencyId Id { get; private set; }
    public IntCode IntCode { get; private set; }
    public ChrCode ChrCode { get; private set; }
    public int Amount { get; private set; }
    public string Name { get; private set; }
    public decimal Rate { get; private set; }
}
