using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Accounts.Application;
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
        public ActionResult<AccountDto> PostAccount(AccountDto accountDto)
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

        [HttpGet("{id}")]
        public ActionResult<AccountDto> GetAccount(AccountId id)
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

        [HttpDelete]
        public ActionResult<AccountDto> DeleteAccount(AccountId id)
        {
            _service.Delete(id);
            return Ok(id);
        }
    }
}
