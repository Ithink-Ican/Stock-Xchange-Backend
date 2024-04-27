using StockMarketApp.Features.InstrumentTypes.Domain;
using StockMarketApp.Features.Industries.Domain;
using StockMarketApp.Features.Issuers.Domain;

namespace StockMarketApp.Features.Instruments.Domain
{
    public class Instrument
    {
        public InstrumentId Id { get; private set; }
        public Code Code { get; private set; }
        public InstrumentTypeId InstrumentTypeId { get; private set; }
        public IndustryId IndustryId { get; private set; }
        public IssuerId IssuerId { get; private set; }
        public bool IsActive { get; private set; }
        private List<Instrument> _SubInstruments;
        public IReadOnlyList<Instrument> SubInstruments => _SubInstruments;
        public Instrument(Code code, InstrumentTypeId instrumentTypeId, IndustryId industryId, IssuerId issuerId, bool isActive)
        {
            Id = new InstrumentId(Guid.NewGuid());
            Code = code;
            InstrumentTypeId = instrumentTypeId;
            IndustryId = industryId;
            IssuerId = issuerId;
            IsActive = isActive;
            _SubInstruments = new List<Instrument>();
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
            if (!this.InstrumentTypeId.Value.Equals(fundId))
            {
                throw new ArgumentException(
                    "У простого инструмента не может быть подчинённых инструментов",
                    nameof(fundId));
            }
            if (this._SubInstruments.Contains(instrument))
            {
                throw new ArgumentException(
                    "Такой инструмент уже есть в списке подчинённых инструментов",
                    nameof(fundId));
            }
            this._SubInstruments.Add(instrument);
        }

        public void RemoveSubInstument(Instrument instrument)
        {
            if (this.SubInstruments.Count == 0)
            {
                throw new ArgumentException(
                    "Список подчинённых инструментов пуст",
                    nameof(instrument));
            }
            this._SubInstruments.Remove(instrument);
        }

        public List<Instrument> GetSubIntruments()
        {
            return _SubInstruments;
        }

        public int GetSubInstrumentsCount()
        {
            return _SubInstruments.Count();
        }
    }
}