namespace StockMarketApp.Features.UserTypes.Domain
{
    public class UserType
    {
        public UserTypeId Id { get; private set; }
        public string Name { get; private set; }

        public UserType(string name)
        {
            Id = new UserTypeId(Guid.NewGuid());
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            Name = name;
        }
        public void ChangeAttributes(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            Name = name;
        }
    }
}
