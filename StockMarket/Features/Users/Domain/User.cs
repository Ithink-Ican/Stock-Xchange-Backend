using System.Security.Cryptography;
using System.Text;
using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Features.Users.Domain
{
    public class User
    {
        public UserId Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public DateTime SignUpDate { get; private set; }
        public UserTypeId UserTypeId { get; private set; }

        private Dictionary<string, string> EncryptPassword(
            string password,
            byte[] salt = null
            )
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            const int keySize = 64;
            const int iterations = 350000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
            if (salt == null)
            {
                salt = RandomNumberGenerator.GetBytes(keySize);
            }         

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            string hex_password = Convert.ToHexString(hash);
            string hex_salt = Convert.ToHexString(salt);
            result.Add("password", hex_password);
            result.Add("salt", hex_salt);
            return result;
        }

        public User(
            UserId id,
            string login,
            string password,
            string email,
            string name, 
            UserTypeId userTypeId
            )
        {
            Id = id;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Введите ФИО",
                    nameof(name));
            }
            var encryptionResult = EncryptPassword(password);
            Login = login;
            Password = encryptionResult["password"];
            Salt = encryptionResult["salt"];
            Email = email;
            Name = name;
            SignUpDate = DateTime.Now;
            UserTypeId = userTypeId;
        }

        public bool ValidatePassword(
            string passwordToValidate,
            string actualPassword,
            string salt
            )
        {
            var hashResult =
                EncryptPassword(passwordToValidate, Convert.FromHexString(salt));
            return CryptographicOperations.FixedTimeEquals(
                Convert.FromHexString(hashResult["password"]),
                Convert.FromHexString(actualPassword)
                );
        }
    }
}
