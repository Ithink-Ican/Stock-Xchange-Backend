using StockMarketApp.Features.Accounts.Application;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace StockMarketApp.Features.Accounts.Presentation.API
{
    public class AccountsControllers : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAccount(
            [FromBody] CreateAccountCommandHandler createAccountCommandHandler)
        {

        }

    }
}
