//using HumanResources.Business.Abstract;
//using HumanResources.Core.Constants;
//using HumanResources.Data.Dtos;
//using HumanResources.Data.Internal.Response;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace HumanResources.Api.Controllers
//{
//    [ApiController]
//    [Route("api/user/[controller]/[action]")]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [HttpGet]
//        public Task<Result<UserDto>> GetProfile()
//        {
//            return _userService.GetProfile();
//        }

//        [HttpPut]
//        public Task<Result<bool>> UpdateProfile(ProfileSaveDto profileSaveDto)
//        {
//            return _userService.UpdateProfile(profileSaveDto);
//        }

//        [HttpPut]
//        public Task<Result<bool>> FreezeAccount()
//        {
//            return _userService.FreezeAccount();
//        }

//        [HttpDelete]
//        public Task<Result<bool>> DeleteAccount()
//        {
//            return _userService.DeleteAccount();
//        }
//    }
//}