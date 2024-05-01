using StockMarketApp.Features.UserTypes.Domain;

namespace StockMarketApp.Features.Users.Domain
{
    public class User
    {
        public UserId Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public DateTime SignUpDate { get; private set; }
        public UserTypeId UserTypeId { get; private set; }

        public User(string login, string password, string email, string name, UserTypeId userTypeId)
        {
            Id = new UserId(Guid.NewGuid());
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Введите ФИО",
                    nameof(name));
            }
            Login = login;
            Password = password;
            Email = email;
            Name = name;
            SignUpDate = DateTime.Now;
            UserTypeId = userTypeId;
        }
    }
}
