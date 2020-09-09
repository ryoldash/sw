using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Application.ApiClient;
using StarWars.RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace StarWars.ApiTests
{
    public abstract class ApiTestBase
    {
        protected IApiClient ApiClient;

        // constructor
        public ApiTestBase()
        {
            Bootstrap();
        }

        /// <summary>
        /// Setup depency injection
        /// </summary>
        private void Bootstrap()
        {
            // setup configurations
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json")
                .Build();

            // setup dependency injection
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services, configuration);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            // get instance of starshipService
            ApiClient = serviceProvider.GetService<IApiClient>();
        }

        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            // Add application services.
            services.AddSingleton<IApiClient>(x => new ApiClient(configuration["ApiBaseUrl"]));
        }
    }
}
