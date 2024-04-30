namespace StockMarketApp.Features.Industries.Domain
{
    public class Industry
    {
        public IndustryId Id { get; private set; }
        public string Name { get; private set; }
        public Industry(IndustryId id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Наименование индустрии не может быть пустым",
                    nameof(name));
            }
            Id = new IndustryId(Guid.NewGuid());
            Name = name;
        }
        public void ChangeAttributes(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Наименование индустрии не может быть пустым",
                    nameof(name));
            }
            Name = name;
        }
    }
}
