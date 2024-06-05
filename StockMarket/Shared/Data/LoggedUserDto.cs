using StockMarket.Features.Users.Domain;
using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Shared.Data;

public class LoggedUserDto
{
    public UserId Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserTypeId UserTypeId { get; set; }

    public LoggedUserDto()
    {
    }

    public static LoggedUserDto Create(
        UserId id,
        string name,
        string email,
        UserTypeId userTypeId
        )
    {
        var dto = new LoggedUserDto();
        dto.Id = id;
        dto.Email = email;
        dto.Name = name;
        dto.UserTypeId = userTypeId;

        return dto;
    }

    public List<LoggedUserDto> BulkConvert(IEnumerable<User> users)
    {
        var list = new List<LoggedUserDto>();
        foreach (var user in users)
        {
            var dto = LoggedUserDto.Create(
                user.Id,
                user.Email,
                user.Name,
                user.UserTypeId
            );
            list.Add(dto);
        }
        return list;
    }
}