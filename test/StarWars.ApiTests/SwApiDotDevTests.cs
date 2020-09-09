using StarWars.Application.Dtos;
using StarWars.Core.Models.Starships;
using StarWars.Core;
using System;
using Xunit;
using System.Threading.Tasks;
using System.Xml;

namespace StarWars.ApiTests
{
    /// <summary>
    /// This is integration testing to test the swapi.dev with implemented Rest Api client. 
    /// </summary>
    public class SwApiDotDevTests : ApiTestBase
    {

        [Fact]
        public async Task SwApiDev_IsAccessible_ReturnsStarships()
        {
            // Arrange           
            var expectedItemCount = 10;

            // Act
            var starships = (await this.ApiClient.GetAsync<ListResultDto<Starship>>(Constants.Endpoints.Starships.Base)).Results;

            // Assert
            Assert.Equal(expectedItemCount, starships.Count);
        }

        [Fact]
        public async Task SwApiDev_InvalidEndpoint_ReturnsXmlException()
        {
            // Assert
            await Assert.ThrowsAsync<XmlException>(() => (this.ApiClient.GetAsync<ListResultDto<Starship>>("/InvalidEndpoint")));
        }

        [Fact]
        public async Task SwApiDev_ValidEndpointWithIncorrectParameter_ReturnsException()
        {
            // Assert
            await Assert.ThrowsAsync<Exception>(() => (this.ApiClient.GetAsync<ListResultDto<Starship>>(Constants.Endpoints.Starships.Base + "p")));
        }

        // TODO: write more test cases for integration testing
    }
}
