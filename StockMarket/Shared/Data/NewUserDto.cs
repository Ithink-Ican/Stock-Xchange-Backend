using StockMarket.Features.Users.Domain;
using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Shared.Data;

public class NewUserDto
{
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }

    public NewUserDto()
    {
    }

    public static NewUserDto Create(
        string password,
        string email,
        string name
        )
    {
        var dto = new NewUserDto();
        dto.Password = password;
        dto.Email = email;
        dto.Name = name;

        return dto;
    }
}