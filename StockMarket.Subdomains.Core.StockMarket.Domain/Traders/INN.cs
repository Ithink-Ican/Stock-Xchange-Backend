using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.StockMarket.Domain.Traders
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
                return null;
            }
            if (!int.TryParse(value, out _value))
            {
                return null;
            }
            if (value.Length > 12)
            {
                return null;
            }

            return new INN(_value);
        }
    }
}
