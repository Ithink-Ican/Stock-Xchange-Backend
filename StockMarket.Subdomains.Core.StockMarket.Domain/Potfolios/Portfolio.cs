using Core.StockMarket.Domain.Instruments;
using Core.StockMarket.Domain.Traders;

namespace Core.StockMarket.Domain.Potfolios
{
    public class Portfolio
    {
        public PortfolioId PortfolioId { get; private set; }
        public TraderId TraderId { get; private set; }
        public InstrumentId InstrumentId { get; private set; }
        public int Amount { get; private set; }
    }
}
