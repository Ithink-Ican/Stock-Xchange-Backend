namespace Core.StockMarket.Domain.Instruments
{
    public class Instrument
    {
        public InstrumentId Id { get; private set; }
        public Code Code { get; private set; }
        public String Name { get; private set; }
        public Guid InstrumentTypeId { get; private set; }
        public Guid IndustryId { get; private set; }
        public Guid IssuerId { get; private set; }
        public bool IsActive { get; private set; }
        public Instrument? SubInstrument { get; private set; }
    }
}
