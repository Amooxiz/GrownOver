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
        private readonly IMediator _mediator;
        private const string sender = "userController";
        public UserController(IUserService userService, IMediator mediator)
        {
            _iUserService = userService;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<UserVM> GetUser(string id)
        {
            //return await _iUserService.GetUser(id);
            return await _mediator.SendGet(sender, id);
        }

        [HttpPost]
        public async Task<IdentityResult> Register([FromBody] RegisterUserRequest user)
        {
            //return await _iUserService.RegisterUser(user.UserName, user.Email, user.Password);
            return await _mediator.SendPost(sender, user);
        }

        [HttpPost]
        public async Task<SignInResult> LogIn([FromBody] LoginUserRequest user)
        {
            return await _mediator.SendPost(sender, user);
        }

        //[HttpGet]
        //public async void LogOut()
        //{
        //   _iUserService.SignOut();
        //}

        [HttpPatch("{id}")]
        public async Task<IdentityResult> Update([FromBody] JsonPatchDocument<User> patch,
            [FromRoute] string id)
        {
            //return await _iUserService.UpdateUser(patch, id);
            return await _mediator.SendPatch(sender, patch, id);
        }

    }
}