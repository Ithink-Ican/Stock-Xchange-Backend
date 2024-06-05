using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.Industries.Domain;
using StockMarket.Features.Issuers.Domain;
using StockMarket.Features.Currencies.Domain;

namespace StockMarket.Features.Instruments.Domain
{
    public class Instrument
    {
        public Instrument()
        {

        }
        public InstrumentId Id { get; private set; }
        public Code Code { get; private set; }
        public InstrumentTypeId InstrumentTypeId { get; private set; }
        public IndustryId IndustryId { get; private set; }
        public string IssuerName { get; private set; }
        public string Description { get; private set; }
        public decimal MarketPrice { get; private set; }
        public CurrencyId CurrencyId { get; private set; }
        public bool IsActive { get; private set; }

        public Instrument(
                InstrumentId id,
                Code code,
                InstrumentTypeId instrumentTypeId,
                IndustryId industryId,
                string issuerName,
                string description,
                decimal marketPrice,
                CurrencyId currencyId,
                bool isActive
                )
            {
                Id = id;
                Code = code;
                InstrumentTypeId = instrumentTypeId;
                IndustryId = industryId;
                IssuerName = issuerName;
                Description = description;
                MarketPrice = marketPrice;
                CurrencyId = currencyId;
                IsActive = isActive;
            }

        public void AddSubInstrument(Instrument instrument,
            InstrumentTypeId fundId)
        {
            if (!InstrumentTypeId.Value.Equals(fundId))
            {
                throw new ArgumentException(
                    "У простого инструмента не может быть подчинённых инструментов",
                    nameof(fundId));
            }
        }
    }
}