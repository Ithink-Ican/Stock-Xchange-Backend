namespace StockMarketApp.Features.Industries.Domain
{
    public class Industry
    {
        public IndustryId _Id { get; private set; }
        public string _Name { get; private set; }
        public Industry(IndustryId id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Наименование индустрии не может быть пустым",
                    nameof(name));
            }
            _Id = new IndustryId(Guid.NewGuid());
            _Name = name;
        }
        public void ChangeAttributes(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Наименование индустрии не может быть пустым",
                    nameof(name));
            }
            _Name = name;
        }
    }
}
