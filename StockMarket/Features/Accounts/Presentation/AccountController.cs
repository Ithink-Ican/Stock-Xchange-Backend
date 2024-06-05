using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Accounts.Application;
using StockMarket.Features.Traders.Domain;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Accounts.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController()
        {
            _service = new AccountService();
        }

        [HttpPost]
        public ActionResult<NewAccountDto> PostAccount(NewAccountDto accountDto)
        {
            _service.Create(accountDto);
            return accountDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountDto>> GetAccounts()
        {
            var dto = new AccountDto();
            var accounts = _service.GetAll().Result;
            var dtos = dto.BulkConvert(accounts);
            return Ok(dtos);
        }

        [HttpGet("/trader-accounts")]
        public ActionResult<IEnumerable<AccountDto>> GetByTrader([FromQuery] TraderId id)
        {
            var accounts = _service.GetByTrader(id).Result;
            if (accounts.Count != 0)
            {
                return accounts;
            }
            return NotFound();
        }

        [HttpGet("/trader-account/currency")]
        public ActionResult<AccountDto> GetByTraderAndCurrency([FromQuery] TraderId id, [FromQuery] Guid currencyId)
        {
            var account = _service.GetByTraderAndCurrency(id, currencyId);
            if (account != null)
            {
                return account;
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<AccountDto> GetAccount([FromQuery] AccountId id)
        {
            var account = _service.Get(id).Result;
            var dto = AccountDto.Create(
                account.Id,
                account.TraderId,
                account.Balance,
                account.CurrencyId
                );
            return Ok(dto);
        }

        [HttpPut]
        public ActionResult<AccountDto> PutAccount(AccountDto account)
        {
            _service.Update(account);
            return Ok(account);
        }

        [HttpPut("/accounts/increase-balance")]
        public ActionResult IncreaseBalance([FromQuery] AccountId id, [FromBody] decimal amount)
        {
            _service.IncreaseBalance(id, amount);
            return Ok();
        }

        [HttpPut("/accounts/decrease-balance")]
        public ActionResult DecreaseBalance([FromQuery] AccountId id, decimal amount)
        {
            _service.DecreaseBalance(id, amount);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteAccount([FromQuery] AccountId id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
