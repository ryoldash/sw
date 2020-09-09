using Moq;
using StarWars.Application.ApiClient;
using StarWars.Application.Dtos;
using StarWars.Application.Starships;
using StarWars.Core.Models.Starships;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Application.Tests.Starships
{
    public abstract class BaseStarshipServiceTests
    {
        private ListResultDto<Starship> starships;
        protected readonly IStarshipService StarshipService;

        public BaseStarshipServiceTests()
        {
            SetupData();

            var mockApiClient = new Mock<IApiClient>();
            mockApiClient.Setup(x => x.GetAsync<ListResultDto<Starship>>(It.IsAny<string>(), null)).Returns(Task.FromResult(this.starships));

            this.StarshipService = new StarshipService(mockApiClient.Object);
        }

        /// <summary>
        /// Sets up the data needed for the tests
        /// </summary>
        protected void SetupData()
        {
            var yWing = new Starship
            {
                Name = "Y-Wing",
                Model = "BTL Y-wing",
                MGLT = "80",
                Consumables = "1 week"
            };

            var millenniumFalcon = new Starship
            {
                Name = "Millennium Falcon",
                Model = "YT-1300 light freighter",
                MGLT = "75",
                Consumables = "2 months"
            };

            var rebelTransport = new Starship
            {
                Name = "Rebel Transport",
                Model = "GR-75 medium transport",
                MGLT = "20",
                Consumables = "6 months"
            };

            var executor = new Starship
            {
                Name = "Executor",
                Model = "Executor-class star dreadnought",
                MGLT = "40",
                Consumables = "6 years"
            };

            this.starships = new ListResultDto<Starship>
            {
                Count = 4,
                Results = new List<Starship>
                {
                    yWing,
                    millenniumFalcon,
                    rebelTransport,
                    executor
                }
            };
        }
    }
}
