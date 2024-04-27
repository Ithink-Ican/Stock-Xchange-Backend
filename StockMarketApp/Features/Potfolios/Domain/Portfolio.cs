﻿using StockMarketApp.Features.Instruments.Domain;
using StockMarketApp.Features.Traders.Domain;

namespace StockMarketApp.Features.Potfolios.Domain
{
    public class Portfolio
    {
        public PortfolioId PortfolioId { get; private set; }
        public TraderId TraderId { get; private set; }
        public InstrumentId InstrumentId { get; private set; }
        public int Amount { get; private set; }

        public Portfolio(TraderId traderId, InstrumentId instrumentId, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Количество не может быть отрицательнм",
                    nameof(amount));
            }
            PortfolioId = new PortfolioId(Guid.NewGuid());
            TraderId = traderId;
            InstrumentId = instrumentId;
            Amount = amount;
        }
    }
}