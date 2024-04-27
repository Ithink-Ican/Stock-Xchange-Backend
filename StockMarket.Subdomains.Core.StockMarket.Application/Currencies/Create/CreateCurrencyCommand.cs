using MediatR;

namespace Core.StockMarket.Application.Currencies.Create;

public record CreateCurrencyCommand(
    int IntCode,
    string ChrCode,
    int Amount,
    string Name,
    double Rate) : IRequest;