using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Currencies.Domain;

namespace StockMarket.Shared.Data;

public class AccountDto
{
    public AccountId Id { get; set; }
    public TraderId TraderId { get; set; }
    public decimal Balance { get; set; }
    public CurrencyId CurrencyId { get; set; }

    public AccountDto()
    {
    }

    public static AccountDto Create(
        AccountId id,
        TraderId traderId,
        decimal balance,
        CurrencyId currencyId
        )
    {
        var dto = new AccountDto();
        dto.Id = id;
        dto.TraderId = traderId;
        dto.Balance = balance;
        dto.CurrencyId = currencyId;
        return dto;
    }

    public List<AccountDto> BulkConvert(IEnumerable<Account> Accounts)
    {
        var list = new List<AccountDto>();
        foreach(var Account in Accounts)
        {
            var dto = AccountDto.Create(
                Account.Id, 
                Account.TraderId, 
                Account.Balance,
                Account.CurrencyId
                );
            list.Add(dto);
        }
        return list;
    }
}
