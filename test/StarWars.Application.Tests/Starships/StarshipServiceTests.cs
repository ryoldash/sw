using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.Application.Tests.Starships
{
    /// <summary>
    /// This class contains integration tests for StarshipService.
    /// </summary>
    public class StarshipServiceTests : BaseStarshipServiceTests
    {
        #region GetAllWithResupplyCountAsync Test Cases

        [Fact]
        public async Task GetAllWithResupplyCountAsync_InputEqualZero_ThrowsArgumentException()
        {
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => (this.StarshipService.GetAllWithResupplyCountAsync(0)));
        }

        [Fact]
        public async Task GetAllWithResupplyCountAsync_ValidInput_ReturnsStarshipsWithResupplyCount()
        {
            // Arrange
            var expectedItemCount = 4;
            ulong distance = 1000000;
            ulong expectedYWingResupplyCount = 74;
            ulong expectedMillenniumFalconResupplyCount = 9;
            ulong expectedRebelTransportResupplyCount = 11;
            ulong expectedExecutorResupplyCount = 0;

            // Act
            var starships = await this.StarshipService.GetAllWithResupplyCountAsync(distance);

            // Assert
            Assert.Equal(expectedItemCount, starships.Count);
            Assert.Equal("Y-Wing", starships[0].Name);
            Assert.Equal(expectedYWingResupplyCount, starships[0].ResupplyCount);

            Assert.Equal("Millennium Falcon", starships[1].Name);
            Assert.Equal(expectedMillenniumFalconResupplyCount, starships[1].ResupplyCount);

            Assert.Equal("Rebel Transport", starships[2].Name);
            Assert.Equal(expectedRebelTransportResupplyCount, starships[2].ResupplyCount);

            Assert.Equal("Executor", starships[3].Name);
            Assert.Equal(expectedExecutorResupplyCount, starships[3].ResupplyCount);
        }

        [Fact]
        public async Task GetAllWithResupplyCountAsync_MaxInputValue_ReturnsStarshipsWithResupplyCount()
        {
            // Arrange
            var expectedItemCount = 4;

            // Act
            var starships = await this.StarshipService.GetAllWithResupplyCountAsync(ulong.MaxValue);

            // Assert
            Assert.Equal(expectedItemCount, starships.Count);
        }

        #endregion

        #region GetAllAsync

        [Fact]
        public async Task GetAllAsync_WithNoParameter_ReturnsAllStarhips()
        {
            // Arrange
            var expectedItemCount = 4;

            // Act
            var starships = await this.StarshipService.GetAllAsync();

            // Assert
            Assert.Equal(expectedItemCount, starships.Count);
            Assert.Equal("Y-Wing", starships[0].Name);
        }

        #endregion
    }
}
