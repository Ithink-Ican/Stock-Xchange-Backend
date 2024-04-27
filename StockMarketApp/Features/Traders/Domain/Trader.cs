namespace StockMarketApp.Features.Traders.Domain
{
    public class Trader
    {
        public TraderId _Id { get; private set; }
        public string _Name { get; private set; }
        public INN _INN { get; private set; }
        public Guid _UserId { get; private set; }

        public Trader(string name, INN iNN, Guid userId)
        {
            _Id = new TraderId(Guid.NewGuid());
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            _Name = name;
            _INN = iNN;
            _UserId = userId;
        }
        public void ChangeAttributes(string name, INN iNN, Guid userId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            _Name = name;
            _INN = iNN;
            _UserId = userId;
        }
    }
}
