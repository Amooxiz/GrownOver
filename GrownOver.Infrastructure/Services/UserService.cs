using GrownOver.Application.Interfaces;
using GrownOver.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace GrownOver.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public readonly UserManager<User> _userManager;
        public readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<IdentityResult> RegisterUser(string UserName, string Email, string Password)
        {
            User appUser = new User { UserName = UserName, Email = Email};
            appUser.HideOut = new HideOut();
            appUser.Inventory = new Inventory();

            IdentityResult result = await _userManager.CreateAsync(appUser, Password);


            return result;
        }

        
        public async Task<SignInResult> SignIn(string UserName, string Password, bool isPersistent = false)
        {
            User appUser = await _userManager.FindByNameAsync(UserName);


            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, Password, isPersistent, false);

            return result;
        }

        public async void SignOut()
        {
            await _signInManager.SignOutAsync();
        }


    }
}
