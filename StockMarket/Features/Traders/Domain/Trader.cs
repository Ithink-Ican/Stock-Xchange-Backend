using StockMarket.Features.Users.Domain;

namespace StockMarket.Features.Traders.Domain
{
    public class Trader
    {
        public Trader()
        {
        }
        public TraderId Id { get; private set; }
        public string Name { get; private set; }
        public INN INN { get; private set; }
        public UserId UserId { get; private set; }

        public Trader(TraderId id, string name, INN iNN, UserId userId)
        {
            Id = id;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            Name = name;
            INN = iNN;
            UserId = userId;
        }
        public void ChangeAttributes(string name, INN iNN, UserId userId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            Name = name;
            INN = iNN;
            UserId = userId;
        }
    }
}
