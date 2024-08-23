using HumanResources.Business.Abstract;
using HumanResources.Core.Constants;
using HumanResources.Data.Dtos;
using HumanResources.Data.Internal.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public Task<Result<IEnumerable<UserPreviewDto>>> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        public Task<Result<UserDto>> Get(long id)
        {
            return _userService.Get(id);
        }

        [HttpPost]
        public Task<Result<bool>> Add(UserDto userDto)
        {
            return _userService.Add(userDto);
        }

        [HttpPut]
        public Task<Result<bool>> Update(UserDto userDto)
        {
            return _userService.Update(userDto);
        }

        [HttpDelete]
        public Task<Result<bool>> Delete(long id)
        {
            return _userService.Delete(id);
        }
    }
}