using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.Industries.Domain;
using StockMarket.Features.Issuers.Domain;

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
        public IssuerId IssuerId { get; private set; }
        public bool IsActive { get; private set; }
        public List<Instrument> SubInstruments { get; private set; }

        public Instrument(
                InstrumentId id,
                Code code,
                InstrumentTypeId instrumentTypeId,
                IndustryId industryId,
                IssuerId issuerId,
                bool isActive,
                List<Instrument> subInstruments
                )
            {
                Id = id;
                Code = code;
                InstrumentTypeId = instrumentTypeId;
                IndustryId = industryId;
                IssuerId = issuerId;
                IsActive = isActive;
                SubInstruments = subInstruments;
            }

        public void ChangeAttributes(
            Code code,
            InstrumentTypeId instrumentTypeId,
            IndustryId industryId,
            IssuerId issuerId,
            bool isActive
            )
        {
            Code = code;
            InstrumentTypeId = instrumentTypeId;
            IndustryId = industryId;
            IssuerId = issuerId;
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
            if (SubInstruments.Contains(instrument))
            {
                throw new ArgumentException(
                    "Такой инструмент уже есть в списке подчинённых инструментов",
                    nameof(fundId));
            }
            SubInstruments.Add(instrument);
        }

        public void RemoveSubInstument(Instrument instrument)
        {
            if (SubInstruments.Count == 0)
            {
                throw new ArgumentException(
                    "Список подчинённых инструментов пуст",
                    nameof(instrument));
            }
            SubInstruments.Remove(instrument);
        }

        public List<Instrument> GetSubIntruments()
        {
            return SubInstruments;
        }

        public int GetSubInstrumentsCount()
        {
            return SubInstruments.Count();
        }
    }
}