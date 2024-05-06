using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Features.Traders.Domain
{
    public class INN
    {
        private INN(int value) => Value = value;
        public int Value { get; private set; }

        public static INN? Create(int value)
        {
            String _value = value.ToString();
            if (value == 0)
            {
                throw new ArgumentException(
                    "ИНН не может быть пустым",
                    nameof(value));
            }
            if (_value.Length > 12 || _value.Length < 10)
            {
                throw new ArgumentException(
                    "ИНН должен быть от 10 до 12 символов длиной",
                    nameof(value));
            }

            return new INN(value);
        }
    }
}
