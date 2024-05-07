using StockMarket.Features.Users.Domain;
using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Shared.Data;

public class UserDto
{
    public UserId Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public DateTime SignUpDate { get; set; }
    public UserTypeId UserTypeId { get; set; }

    public UserDto()
    {
    }

    public static UserDto Create(
        UserId id,
        string name,
        string email,
        string password,
        string salt,
        DateTime signUpDate,
        UserTypeId userTypeId
        )
    {
        var dto = new UserDto();
        dto.Id = id;
        dto.Password = password;
        dto.Salt = salt;
        dto.Email = email;
        dto.Name = name;
        dto.SignUpDate = signUpDate;
        dto.UserTypeId = userTypeId;

        return dto;
    }

    public List<UserDto> BulkConvert(IEnumerable<User> users)
    {
        var list = new List<UserDto>();
        foreach (var user in users)
        {
            var dto = UserDto.Create(
                user.Id,
                user.Password,
                user.Salt,
                user.Email,
                user.Name,
                user.SignUpDate,
                user.UserTypeId
            );
            list.Add(dto);
        }
        return list;
    }
}