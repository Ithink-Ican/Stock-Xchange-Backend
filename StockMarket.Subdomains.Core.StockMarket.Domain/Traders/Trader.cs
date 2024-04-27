namespace Core.StockMarket.Domain.Traders
{
    public class Trader
    {
        public TraderId Id { get; private set; }
        public string Name { get; private set; }
        public INN INN { get; private set; }
        public UserId UserId { get; private set; }
    }
}
