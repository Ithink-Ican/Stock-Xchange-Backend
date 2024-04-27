using Core.StockMarket.Domain.Instruments;
using Core.StockMarket.Domain.Currencies;

namespace Core.StockMarket.Domain.Offers
{
    public class Offer
    {
        public OfferId Id { get; internal set; }
        public Guid TraderId { get; internal set; }
        public InstrumentId InstrumentId { get; internal set; }
        public int Amount { get; internal set; }
        public decimal Price { get; internal set; }
        public CurrencyId CurrencyId { get; internal set; }
        public bool IsSale { get; internal set; }
        public DateTime PlacementDate { get; internal set; }
    }
}
