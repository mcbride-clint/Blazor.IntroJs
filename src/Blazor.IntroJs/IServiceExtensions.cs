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
            services.AddTransient<IntroJsInterop>();
            services.AddTransient<IntroJsInteropEvents>(_ => null);
            services.AddSingleton<IntroJsOptions>(_ => null);

            return services;
        }

        public static IServiceCollection AddIntroJs(this IServiceCollection services, Func<IntroJsOptions> func)
        {
            services.AddTransient<IntroJsInterop>();
            services.AddTransient<IntroJsInteropEvents>();
            services.AddSingleton<IntroJsOptions>(_ => func.Invoke());

            return services;
        }
    }
}
