using System.Security.Cryptography;
using System.Text;

namespace StockMarket.Features.Users.Application
{
    public class PasswordEncryptor
    {
        public PasswordEncryptor()
        {

        }

        public Dictionary<string, string> EncryptPassword(
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

        public bool ValidatePassword(
            string passwordToValidate,
            string actualPassword,
            string salt
            )
        {
            var hashResult =
                EncryptPassword(passwordToValidate, Convert.FromHexString(salt));
            Console.WriteLine("CONSOLE: " + hashResult["password"] + " " + passwordToValidate);
            return CryptographicOperations.FixedTimeEquals(
                Convert.FromHexString(hashResult["password"]),
                Convert.FromHexString(actualPassword)
                );
        }
    }
}
