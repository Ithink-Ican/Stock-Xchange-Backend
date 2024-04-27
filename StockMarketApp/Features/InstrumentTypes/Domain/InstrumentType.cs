namespace StockMarketApp.Features.InstrumentTypes.Domain
{
    public class InstrumentType
    {
        public InstrumentTypeId _Id { get; private set; }
        public string _Name { get; private set; }

        public InstrumentType(InstrumentTypeId id, string name)
        {
            _Id = new InstrumentTypeId(Guid.NewGuid());
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название вида инструмента не может быть пустым",
                    nameof(name));
            }
            _Name = name;
        }

        public void ChangeAttributes(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название вида инструмента не может быть пустым",
                    nameof(name));
            }
            _Name = name;
        }
    }
}
