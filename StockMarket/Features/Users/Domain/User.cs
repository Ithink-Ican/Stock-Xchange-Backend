using System.Text;using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Features.Users.Domain
{
    public class User
    {
        public UserId Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public DateTime SignUpDate { get; private set; }
        public UserTypeId UserTypeId { get; private set; }

        public User(
            UserId id,
            string name,
            string email,
            string password,
            string salt
            )
        {
            Id = id;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Введите ФИО",
                    nameof(name));
            }
            Password = password;
            Salt = salt;
            Email = email;
            Name = name;
            SignUpDate = DateTime.Now;
            UserTypeId = new UserTypeId(Guid.Parse("b32c86e0-df70-4156-a039-58dfa666eeb4"));
        }
    }
}
