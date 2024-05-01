namespace StockMarketApp.Features.Issuers.Domain
{
    public class Issuer
    {
        public IssuerId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Issuer(IssuerId id, string name, string description)
        {
            Id = new IssuerId(Guid.NewGuid());
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Наименование эмитента не может быть пустым",
                    nameof(name));
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException(
                    "Описание эмитента не может быть пустым",
                    nameof(description));
            }
            Name = name;
            Description = description;
        }
        public void ChangeAttributes(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Наименование эмитента не может быть пустым",
                    nameof(name));
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException(
                    "Описание эмитента не может быть пустым",
                    nameof(description));
            }
            Name = name;
            Description = description;
        }
    }
}
