using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.IntroJs
{
    public static class IServiceExtensions
    {
        public static IServiceCollection AddIntroJs(this IServiceCollection services)
        {
            services.AddScoped<IntroJs>();

            return services;
        }
    }
}
