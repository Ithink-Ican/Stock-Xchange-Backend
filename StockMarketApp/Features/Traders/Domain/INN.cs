using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp.Features.Traders.Domain
{
    public class INN
    {
        private INN(int value) => Value = value;
        public int Value { get; private set; }

        public static INN? Create(string value)
        {
            int _value = 0;
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "ИНН не может быть пустым",
                    nameof(value));
            }
            if (!int.TryParse(value, out _value))
            {
                throw new ArgumentException(
                    "ИНН должен состоять только из целых чисел",
                    nameof(value));
            }
            if (value.Length > 12 || value.Length < 10)
            {
                throw new ArgumentException(
                    "ИНН должен быть от 10 до 12 символов длиной",
                    nameof(value));
            }

            return new INN(_value);
        }
    }
}
