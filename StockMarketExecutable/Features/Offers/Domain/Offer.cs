using StockMarketApp.Features.Currencies.Domain;
using StockMarketApp.Features.Instruments.Domain;
using StockMarketApp.Features.Traders.Domain;

namespace StockMarketApp.Features.Offers.Domain
{
    public class Offer
    {
        public OfferId Id { get; private set; }
        public TraderId TraderId { get; private set; }
        public InstrumentId InstrumentId { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
        public CurrencyId CurrencyId { get; private set; }
        public bool IsSale { get; private set; }
        public bool IsSatisfied { get; private set; }
        public DateTime PlacementDate { get; private set; }

        public Offer(TraderId traderId, InstrumentId instrumentId, int amount, decimal price, CurrencyId currencyId, bool isSale)
        {
            if (price <= 0)
            {
                throw new ArgumentException(
                    "Сумма предложения должна быть больше нуля",
                    nameof(price));
            }
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Количество не может быть отрицательнм",
                    nameof(amount));
            }
            Id = new OfferId(Guid.NewGuid());
            TraderId = traderId;
            InstrumentId = instrumentId;
            Amount = amount;
            Price = price;
            CurrencyId = currencyId;
            IsSale = isSale;
            PlacementDate = DateTime.Now;
            IsSatisfied = false;
        }

        public void ChangeAttributes(TraderId traderId, InstrumentId instrumentId, int amount, decimal price, CurrencyId currencyId, bool isSale, bool isSatisfied)
        {
            if (price <= 0)
            {
                throw new ArgumentException(
                    "Сумма предложения должна быть больше нуля",
                    nameof(price));
            }
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Количество не может быть отрицательнм",
                    nameof(amount));
            }
            Id = new OfferId(Guid.NewGuid());
            TraderId = traderId;
            InstrumentId = instrumentId;
            Amount = amount;
            Price = price;
            CurrencyId = currencyId;
            IsSale = isSale;
            IsSatisfied = isSatisfied;
        }

        public void Satisfy()
        {
            IsSatisfied = true;
        }

        public void PartialSale(int amount)
        {
            if (Amount - amount < 0)
            {
                throw new ArgumentException(
                    "Нельзя купить больше, чем предложено",
                    nameof(amount));
            }
            Amount -= amount;
        }

        public void FullSale()
        {
            Amount = 0;
            Satisfy();
        }
    }
}