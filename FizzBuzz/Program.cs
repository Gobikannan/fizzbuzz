using FizzBuzz.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            // configure all services
            var services = ConfigureServices();
            // creates the service providers
            var serviceProvider = services.BuildServiceProvider();
            // run the starting app
            serviceProvider.GetService<FizzBuzzRunner>().Run();
        }

        /// <summary>
        /// Configure all services - DI
        /// </summary>
        /// <returns></returns>
        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            // register all services
            services.AddTransient<IFizzBuzzService, FizzBuzzService>();
            
            // Register our application entry point
            services.AddTransient<FizzBuzzRunner>();
            return services;
        }
    }
}
