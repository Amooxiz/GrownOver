﻿using GrownOver.Application.Interfaces;
using GrownOver.Domain.Models;
using GrownOver.Infrastructure.Responses;
using GrownOver.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using GrownOver.Application.ViewModels;

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
            appUser.nickName = UserName;
            appUser.Inventory = new Inventory();
            appUser.Inventory.armor = new Armor();
            appUser.Inventory.weapon = new Weapon();
            appUser.Inventory.food = new Food();
            appUser.Inventory.material = new Material();
            IdentityResult result = await _userManager.CreateAsync(appUser, Password);
            
            if (result.Succeeded)
            {
                UserRegisterResponse response = new UserRegisterResponse()
                {
                    Succeeded = result.Succeeded,
                    Id = appUser.Id,
                    Errors = result.Errors
                };

                return response;
            }

            return result;
        }

        
        public async Task<SignInResult> SignIn(string UserName, string Password, bool isPersistent = false)
        {
            User appUser = await _userManager.FindByNameAsync(UserName);


            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, Password, isPersistent, false);

            if (result.Succeeded)
            {
                UserLoginResponse response = new UserLoginResponse() 
                {
                    IsLockedOut = result.IsLockedOut,
                    Id = appUser.Id,
                    Succeeded = result.Succeeded,
                    IsNotAllowed = result.IsNotAllowed,
                    RequiresTwoFactor = result.RequiresTwoFactor
                 };

                return response;
            }

            return result;
        }

        public async void SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserVM> GetUser(string id)
        {
            var user = _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new NullReferenceException("user jest nullem");
            }

            UserVM userVM = new UserVM()
            {
                Id = user.Result.Id,
                UserName = user.Result.UserName,
                Health = user.Result.Health,
                Efficiency = user.Result.Efficiency,
                Power = user.Result.Power,
                Ingenuity = user.Result.Ingenuity,
                Charisma = user.Result.Charisma,
                Awereness = user.Result.Awereness,
                Experience = user.Result.Experience,
                HideOutId = user.Result?.HideOut?.Id,
                InventoryId = user.Result?.Inventory?.Id,
                PointsLeft = user.Result.PointsLeft
            };
            return userVM;
        }


    }
}
