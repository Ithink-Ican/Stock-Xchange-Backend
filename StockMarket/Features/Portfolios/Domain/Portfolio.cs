using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.Traders.Domain;

namespace StockMarket.Features.Portfolios.Domain
{
    public class Portfolio
    {
        public PortfolioId Id { get; private set; }
        public TraderId TraderId { get; private set; }
        public InstrumentId InstrumentId { get; private set; }
        public int Amount { get; private set; }

        public Portfolio(PortfolioId id, TraderId traderId, InstrumentId instrumentId, int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(
                    "Количество не может быть отрицательнм",
                    nameof(amount));
            }
            Id = id;
            TraderId = traderId;
            InstrumentId = instrumentId;
            Amount = amount;
        }

        public void ChangeAmount(int amount)
        {
            Amount = amount;
        }

        public void IncreaseAmount(int amount)
        {
            Amount += amount;
        }

        public void DecreaseAmount(int amount)
        {
            Amount -= amount;
        }
    }
}
