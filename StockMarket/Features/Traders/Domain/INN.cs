using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Features.Traders.Domain
{
    public class INN
    {
        private INN(string value) => Value = value;
        public string Value { get; private set; }

        public static INN? Create(string value)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException(
                    "ИНН не может быть пустым",
                    nameof(value));
            }
            if (value.Length > 12 || value.Length < 10)
            {
                throw new ArgumentException(
                    "ИНН должен быть от 10 до 12 символов длиной",
                    nameof(value));
            }

            return new INN(value);
        }
    }
}
