using GrownOver.Application.Interfaces;
using GrownOver.Infrastructure.Data;
using GrownOver.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using GrownOver.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using GrownOver.Infrastructure.Repositories;

namespace GrownOver.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddProjectService(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<GrownOverDbContext>(options =>
                options.UseSqlServer(conf.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredLength = 8;
            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<GrownOverDbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<User, GrownOverDbContext>(opt =>
            //    {
            //        opt.IdentityResources["openid"].UserClaims.Add("role");
            //     opt.ApiResources.Single().UserClaims.Add("role");
            //    });
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWeaponService, WeaponService>();
            services.AddTransient<IWeaponRepository, WeaponRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IHideOutService, HideOutService>();
            services.AddTransient<IHideOutRepository, HideOutRepository>();
            services.AddTransient<IBaseItemRepository, BaseItemRepository>();
            services.AddTransient<IBaseItemService, BaseItemService>();
            return services;
        }
    }
}
