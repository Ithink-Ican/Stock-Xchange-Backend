using MediatR;
using StockMarketApp.Features.Traders.Domain;
using StockMarketApp.Features.Currencies.Domain;

namespace StockMarketApp.Features.Accounts.Application
{
    public record CreateAccountCommand(
        TraderId traderId,
        decimal Balance,
        CurrencyId currencyId
        ) : IRequest;
}