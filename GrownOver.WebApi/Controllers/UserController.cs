using Microsoft.AspNetCore.Mvc;
using GrownOver.Contracts.RequestsModels;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Cors;
using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using GrownOver.Domain.Models;

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

        [HttpGet("{id}")]
        public async Task<UserVM> GetUser(string id)
        {
            return await _iUserService.GetUser(id);
        }

        [HttpPost]
        public async Task<IdentityResult> Register([FromBody] RegisterUserRequest user)
        {
            return await _iUserService.RegisterUser(user.UserName, user.Email, user.Password);
        }

        [HttpPost]
        public async Task<SignInResult> LogIn([FromBody] LoginUserRequest user)
        {
            return await _iUserService.SignIn(user.UserName, user.Password);
        }

        [HttpGet]
        public async void LogOut([FromBody] LoginUserRequest user)
        {
           _iUserService.SignOut();
        }

        [HttpPatch("{id}")]
        public async Task<IdentityResult> Update([FromBody] JsonPatchDocument<User> patch,
            [FromRoute] string id)
        {
            return await _iUserService.UpdateUser(patch, id);
        }

    }
}