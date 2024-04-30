using MediatR;
using StockMarketApp.Common.Infrastructure;
using StockMarketApp.Features.Accounts.Domain;

namespace StockMarketApp.Features.Accounts.Application
{
    internal class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(
                request.traderId,
                request.Balance,
                request.currencyId
                );

            _accountRepository.Add(account);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
