namespace StockMarket.Features.Currencies.Domain;

public class Currency
{
    public CurrencyId Id { get; private set; }
    public IntCode IntCode { get; private set; }
    public ChrCode ChrCode { get; private set; }
    public int Amount { get; private set; }
    public string Name { get; private set; }
    public decimal Rate { get; private set; }

    public Currency(
        CurrencyId id, 
        IntCode intCode, 
        ChrCode chrCode, 
        int amount, string 
        name, 
        decimal rate
        )
    {
        Id = id;
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Количество валюты не может быть отрицательнм",
                nameof(amount));
        }
        if (rate <= 0)
        {
            throw new ArgumentException(
                "Курс не может быть отрицательным",
                nameof(amount));
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException(
                "Название валюты не может быть пустым",
                nameof(name));
        }
        IntCode = intCode;
        ChrCode = chrCode;
        Amount = amount;
        Name = name;
        Rate = rate;
    }

    public void ChangeAttributes(IntCode intCode, ChrCode chrCode, int amount, string name, decimal rate)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Количество валюты не может быть отрицательнм",
                nameof(amount));
        }
        if (rate <= 0)
        {
            throw new ArgumentException(
                "Курс не может быть отрицательным",
                nameof(amount));
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException(
                "Название валюты не может быть пустым",
                nameof(name));
        }
        IntCode = intCode;
        ChrCode = chrCode;
        Amount = amount;
        Name = name;
        Rate = rate;
    }

    public void ChangeIntCode(IntCode intCode)
    {
        IntCode = intCode;
    }

    public void ChangeChrCode(ChrCode chrCode)
    {
        ChrCode = chrCode;
    }

    public void ChangeAmount(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Количество валюты не может быть отрицательнм",
                nameof(amount));
        }
        Amount = amount;
    }

    public void ChangeRate(decimal rate)
    {
        if (rate <= 0)
        {
            throw new ArgumentException(
                "Курс не может быть отрицательным",
                nameof(rate));
        }
        Rate = rate;
    }
}
