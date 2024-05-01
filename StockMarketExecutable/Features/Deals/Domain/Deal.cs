using StockMarketApp.Features.Offers.Domain;

namespace StockMarketApp.Features.Deals.Domain
{
    public class Deal
    {
        public DealId Id { get; private set; }
        public OfferId SellOfferId { get; private set; }
        public OfferId BuyOfferId { get; private set; }
        public DateTime DealDate { get; private set; }

        public static Deal Create(
            OfferId sellOfferId,
            OfferId buyOfferId,
            int amountToSell,
            int amountToBuy
            )
        {
            if (sellOfferId == buyOfferId)
            {
                throw new ArgumentException(
                    "Нельзя заключать сделки с самим собой",
                    nameof(sellOfferId));
            }
            if (amountToSell < amountToBuy)
            {
                //sellOffer.PartialSale(buyOffer.Amount);
            }
            if (amountToSell == amountToBuy)
            {
                //sellOffer.FullSale();
            }
            // buyOffer.Satisfy();
            var deal = new Deal()
            {
                Id = new DealId(Guid.NewGuid()),
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
