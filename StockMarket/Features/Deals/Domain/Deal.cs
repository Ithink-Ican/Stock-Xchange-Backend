using StockMarket.Features.Offers.Domain;

namespace StockMarket.Features.Deals.Domain
{
    public class Deal
    {
        public DealId Id { get; private set; }
        public OfferId SellOfferId { get; private set; }
        public OfferId BuyOfferId { get; private set; }
        public DateTime DealDate { get; private set; }

        public static Deal Create(
            DealId id,
            OfferId sellOfferId,
            OfferId buyOfferId
            )
        {
            if (sellOfferId == buyOfferId)
            {
                throw new ArgumentException(
                    "Нельзя заключать сделки с самим собой",
                    nameof(sellOfferId));
            }
            var deal = new Deal()
            {
                Id = id,
                SellOfferId = sellOfferId,
                BuyOfferId = buyOfferId,
                DealDate = DateTime.Now
            };
            return deal;
        }
        

        public void ChangeAttributes(OfferId sellOfferId, OfferId buyOfferId)
        {
            if (sellOfferId == buyOfferId)
            {
                throw new ArgumentException(
                    "Нельзя заключать сделки с самим собой",
                    nameof(sellOfferId));
            }
            SellOfferId = sellOfferId;
            BuyOfferId = buyOfferId;
        }
    }
}
