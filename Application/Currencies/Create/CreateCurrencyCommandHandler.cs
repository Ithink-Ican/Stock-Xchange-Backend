using Domain.Currencies;
using MediatR;

namespace Application.Currencies.Create;

internal class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand>
{
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IUnitOfWork 
    public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public Task Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = new Currency(
            new CurrencyId(Guid.NewGuid()),
            request.IntCode,
            request.ChrCode,
            request.Amount,
            request.Name,
            request.Rate
            );
        _currencyRepository.Add(currency);
    }
}
