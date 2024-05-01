﻿namespace StockMarketApp.Features.Traders.Domain
{
    public class Trader
    {
        public TraderId Id { get; private set; }
        public string Name { get; private set; }
        public INN INN { get; private set; }
        public Guid UserId { get; private set; }

        public Trader(string name, INN iNN, Guid userId)
        {
            Id = new TraderId(Guid.NewGuid());
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            Name = name;
            INN = iNN;
            UserId = userId;
        }
        public void ChangeAttributes(string name, INN iNN, Guid userId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Название не может быть пустым",
                    nameof(name));
            }
            Name = name;
            INN = iNN;
            UserId = userId;
        }
    }
}
