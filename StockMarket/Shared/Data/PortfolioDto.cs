using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Portfolios.Domain;

namespace StockMarket.Shared.Data;

public class PortfolioDto
{
    public PortfolioId Id { get; set; }
    public TraderId TraderId { get; set; }
    public InstrumentId InstrumentId { get; set; }
    public int Amount { get; set; }
    public InstrumentDto? Instrument { get; set; }
    public PortfolioDto()
    {
    }

    public static PortfolioDto Create(
        PortfolioId id,
        TraderId traderId,
        InstrumentId instrumentId,
        int amount,
        InstrumentDto? instrument=null
        )
    {
        var dto = new PortfolioDto();
        dto.Id = id;
        dto.TraderId = traderId;
        dto.InstrumentId = instrumentId;
        dto.Amount = amount;
        dto.Instrument = instrument;

        return dto;
    }

    public List<PortfolioDto> BulkConvert(IEnumerable<Portfolio> portfolios)
    {
        var list = new List<PortfolioDto>();
        foreach (var portfolio in portfolios)
        {
            var dto = PortfolioDto.Create(
                portfolio.Id,
                portfolio.TraderId,
                portfolio.InstrumentId,
                portfolio.Amount
            );
            list.Add(dto);
        }
        return list;
    }
}