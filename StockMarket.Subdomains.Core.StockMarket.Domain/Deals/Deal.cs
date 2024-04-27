using Core.StockMarket.Domain.Offers;

namespace Core.StockMarket.Domain.Deals
{
    public class Deal
    {
        public DealId Id { get; private set; }
        public OfferId SellOfferId { get; private set; }
        public OfferId BuyOfferId { get; private set; }
        public DateTime DealDate { get; private set; }
    }
}
