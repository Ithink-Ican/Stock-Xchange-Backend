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
        public ActionResult<UserDto> PostUser(UserDto userDto)
        {
            _service.Create(userDto);
            return CreatedAtAction("PostUser", new { id = userDto.Id }, userDto);
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
        public ActionResult<UserDto> GetUser(UserId id)
        {
            var user = _service.Get(id).Result;
            var dto = UserDto.Create(
                user.Id,
                user.Login,
                user.Password,
                user.Email,
                user.Name,
                user.SignUpDate,
                user.UserTypeId
                );
            Console.WriteLine("controller" + user.Name + user.Password);
            return Ok(dto);
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

        [HttpGet("{id}, {password}")]
        public ActionResult<bool> Login(UserId id, string password)
        {
            var result = _service.Login(id, password);
            if (result)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
    }
}
