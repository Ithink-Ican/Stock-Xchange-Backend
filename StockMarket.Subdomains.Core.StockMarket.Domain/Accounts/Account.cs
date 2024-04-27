using Core.StockMarket.Domain.Currencies;
using Core.StockMarket.Domain.Traders;

namespace Core.StockMarket.Domain.Accounts
{
    public class Account
    {
        public AccountId Id { get; private set; }
        public TraderId TraderId { get; private set; }
        public decimal Balance { get; private set; }
        public CurrencyId CurrencyId { get; private set; }

    }
}
