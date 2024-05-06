using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Shared.Data
{
    public class UserTypeDto
    {
        public UserTypeId Id { get; set; }
        public string Name { get; set; }
        public UserTypeDto()
        {
        }

        public static UserTypeDto Create(
            UserTypeId id,
            string name
            )
        {
            var dto = new UserTypeDto();
            dto.Id = id;
            dto.Name = name;

            return dto;
        }

        public List<UserTypeDto> BulkConvert(IEnumerable<UserType> userTypes)
        {
            var list = new List<UserTypeDto>();
            foreach (var userType in userTypes)
            {
                var dto = UserTypeDto.Create(
                    userType.Id,
                    userType.Name
                );
                list.Add(dto);
            }
            return list;
        }
    }
}
