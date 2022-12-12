using Microsoft.AspNetCore.Identity;

namespace GrownOver.Application.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterUser(string UserName, string Email, string Password);
        public Task<SignInResult> SignIn(string UserName, string Password, bool isPersistent = false);
        public void SignOut();
    }
}
