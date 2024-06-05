namespace StockMarket.Features.Instruments.Domain
{
    public record Code
    {
        public Code() { }
        private Code(string value) => Value = value;
        public string Value { get; init; }

        public static Code? Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "Код не может быть пустым",
                    nameof(value));
            }

            if (value.Length > 5)
            {
                throw new ArgumentException(
                    "Код не может быть длиннее 5 символов",
                    nameof(value));
            }

            return new Code(value);
        }
    }
}
