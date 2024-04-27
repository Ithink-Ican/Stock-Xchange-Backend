namespace StockMarketApp.Features.Issuers.Domain
{
    public class Issuer
    {
        public IssuerId _Id { get; private set; }
        public string _Name { get; private set; }
        public string _Description { get; private set; }

        public Issuer(IssuerId id, string name, string description)
        {
            _Id = new IssuerId(Guid.NewGuid());
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
            _Name = name;
            _Description = description;
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
            _Name = name;
            _Description = description;
        }
    }
}
