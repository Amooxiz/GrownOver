using GrownOver.Application.Interfaces;
using GrownOver.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Contracts
{
    public static class AddContracts
    {
        public static IServiceCollection AddContractsServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, Mediator>();
            return services;
        }
    }
}
