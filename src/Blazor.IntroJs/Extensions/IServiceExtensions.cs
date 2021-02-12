using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blazor.IntroJs
{
    /// <summary>
    /// IServiceCollection Extensions to add IntroJs objects to services
    /// </summary>
    public static class IServiceExtensions
    {
        /// <summary>
        /// Adds IntroJs classes to Service collection using default IntroJs Options
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddIntroJs(this IServiceCollection services, IConfiguration configuration = null)
        {
            IntroJsOptions options = null;

            if (configuration != null)
            {
                options = configuration.GetSection(nameof(IntroJsOptions)).Get<IntroJsOptions>();
            }

            services.AddTransient<IntroJsInterop>();
            services.AddTransient<IntroJsInteropEvents>();
            services.AddTransient<IntroJsOptions>(_ => options);

            return services;
        }

        /// <summary>
        /// Adds IntroJs classes to Service collection using IntroJsOptions created by function
        /// </summary>
        /// <param name="services"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IServiceCollection AddIntroJs(this IServiceCollection services, Func<IntroJsOptions> func)
        {
            services.AddTransient<IntroJsInterop>();
            services.AddTransient<IntroJsInteropEvents>();
            services.AddTransient<IntroJsOptions>(_ => func.Invoke());

            return services;
        }
    }
}
