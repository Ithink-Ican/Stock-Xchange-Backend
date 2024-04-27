namespace Domain.Instruments
{
    public record Code
    {
        private Code(string value) => Value = value;
        public string Value { get; init; }

        public static Code? Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            if (value.Length > 5)
            {
                return null;
            }

            return new Code(value);
        }
    }
}
