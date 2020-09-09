using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Application.ApiClient;
using StarWars.Application.Starships;
using StarWars.RestSharp;

namespace StarWars.ConsoleApp
{
    class Program
    {
        private static IStarshipService starshipService;

        static void Main(string[] args)
        {
            // prepare dependencies
            Bootstrap();

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            char action = 'Y'; // this variable is used to control the flow of loop

            while (action == 'Y')
            {
                Console.Clear();
                Console.WriteLine("*********************************************************************************************");
                Console.WriteLine("*                                                                                           *");
                Console.WriteLine("*               Welcome to StarWars Starship Resupply Calculation System :)                 *");
                Console.WriteLine($"*                                                                                v{version}   *");
                Console.WriteLine("*********************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("Please enter the destination planet distance(MGLT):");

                try
                {
                    ulong distance = Convert.ToUInt64(Console.ReadLine());

                    if (distance > 0)
                    {
                        var starships = starshipService.GetAllWithResupplyCountAsync(distance).Result;

                        Console.WriteLine("\n\nHey there, this sytem worked :) And here is the output: \n");

                        starships.ForEach(starship => Console.WriteLine(starship));
                    }
                    else
                    {
                        Console.WriteLine("\n\nError: Distance cannot be negative. Please try again!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("\n\nError: Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fatal Error: Unhandled exception occured.");

                    // TODO: Log the error. Serilog can be used for logging and Kibanna can be used to visualize the logs.
                }             

                Console.WriteLine("\n\n\nDo you want to calculate resupply count for another planet!");
                Console.WriteLine("Press Y to continue");
                Console.WriteLine("Press any key to exit");
                action = Console.ReadKey().KeyChar;
            }
        }

        /// <summary>
        /// Setup depency injection
        /// </summary>
        private static void Bootstrap()
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
            starshipService = serviceProvider.GetService<IStarshipService>();
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
            services.AddTransient<IStarshipService, StarshipService>();
        }
    }
}
