using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Features.UserTypes.Domain;
using StockMarket.Features.UserTypes.Application;
using StockMarket.Shared.Data;

namespace StockMarket.Features.UserTypes.Presentation;

[ApiController]
[Route("[controller]")]
public class UserTypeController : ControllerBase
{
    private readonly IUserTypeService _service;

    public UserTypeController()
    {
        _service = new UserTypeService();
    }

    [HttpPost]
    public ActionResult<UserTypeDto> Post(UserTypeDto userTypeDto)
    {
        _service.Create(userTypeDto);
        return userTypeDto;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserTypeDto>> GetAll()
    {
        var dto = new UserTypeDto();
        var userTypes = _service.GetAll().Result;
        var dtos = dto.BulkConvert(userTypes);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public ActionResult<UserTypeDto> GetById(UserTypeId id)
    {
        var userType = _service.Get(id).Result;
        var dto = UserTypeDto.Create(
                userType.Id,
                userType.Name
            );
        return Ok(dto);
    }

    [HttpPut]
    public ActionResult<UserTypeDto> Put(UserTypeDto userType)
    {
        _service.Update(userType);
        return Ok(userType);
    }

    [HttpDelete]
    public ActionResult<UserTypeDto> Delete(UserTypeId id)
    {
        _service.Delete(id);
        return Ok(id);
    }
}
