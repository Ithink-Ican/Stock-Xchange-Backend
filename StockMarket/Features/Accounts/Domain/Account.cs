using StockMarket.Features.Currencies.Domain;
using StockMarket.Features.Traders.Domain;

namespace StockMarket.Features.Accounts.Domain
{
    public class Account
    {
        public Account()
        {
        }
        public AccountId Id { get; private set; }
        public TraderId TraderId { get; private set; }
        public decimal Balance { get; private set; }
        public CurrencyId CurrencyId { get; private set; }

        public Account(AccountId id, TraderId traderId, decimal balance, CurrencyId currencyId)
        {
            Id = id;
            if (balance < 0)
            {
                throw new ArgumentException(
                    "Баланс не может быть отрицательным", nameof(balance));
            }
            TraderId = traderId;
            Balance = balance;
            CurrencyId = currencyId;
        }

        public void ChangeAttributes(decimal balance)
        {
            if (balance < 0)
            {
                throw new ArgumentException(
                    "Баланс не может быть отрциательным", nameof(balance));
            }
            Balance = balance;
        }

        public void IncreaseBalance(decimal amount)
        {
            if (Balance + amount < 0)
            {
                throw new ArgumentException(
                    "Баланс не может быть отрицательным после пополнения",
                    nameof(amount));
            }
            Balance += amount;
        }

        public void DecreaseBalance(decimal amount)
        {
            if (Balance - amount < 0)
            {
                throw new ArgumentException(
                    "Баланс не может быть отрицательным после списания",
                    nameof(amount));
            }
            Balance -= amount;
        }
    }
}
