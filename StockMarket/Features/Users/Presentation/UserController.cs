using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.Users.Domain;
using StockMarket.Features.Users.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.Users.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController()
        {
            _service = new UserService();
        }

        [HttpPost]
        public ActionResult<NewUserDto> PostUser(
            NewUserDto dto
            )
        {
            _service.Create(dto);
            return CreatedAtAction("PostUser", new { email = dto.Email }, dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var dto = new UserDto();
            var users = _service.GetAll().Result;
            var dtos = dto.BulkConvert(users);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser([FromQuery] string email)
        {
            var user = _service.Get(email).Result;
            var dto = UserDto.Create(
                user.Id,
                user.Password,
                user.Salt,
                user.Email,
                user.Name,
                user.SignUpDate,
                user.UserTypeId
                );
            return dto;
        }

        [HttpPut]
        public ActionResult<UserDto> PutUser(UserDto user)
        {
            _service.Update(user);
            return Ok(user);
        }

        [HttpDelete]
        public ActionResult<UserDto> DeleteUser(UserId id)
        {
            _service.Delete(id);
            return Ok(id);
        }

        [HttpGet("{email}&{password}")]
        public ActionResult<string> Login([FromQuery] string email, [FromQuery] string password)
        {
            var result = _service.Login(email, password);
            if (result != "")
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
    }
}
