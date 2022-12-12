using Microsoft.AspNetCore.Mvc;
using GrownOver.Contracts.RequestsModels;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Cors;
using GrownOver.Application.Interfaces;

namespace GrownOver.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;
        public UserController(IUserService userService)
        {
            _iUserService = userService;
        }

        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<IdentityResult> Register([FromBody] RegisterUserRequest user)
        {
            return await _iUserService.RegisterUser(user.UserName, user.Email, user.Password);
        }

        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<SignInResult> LogIn([FromBody] LoginUserRequest user)
        {
            return await _iUserService.SignIn(user.UserName, user.Password);
        }

        [EnableCors("Policy1")]
        [HttpGet]
        public void LogOut([FromBody] LoginUserRequest user)
        {
            _iUserService.SignOut();
        }
    }
}