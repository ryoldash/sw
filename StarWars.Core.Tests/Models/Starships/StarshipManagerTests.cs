using StarWars.Core.Models.Starships;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StarWars.Core.Tests.Models.Starships
{
    /// <summary>
    /// This class contains unit tests for StarshipManager.
    /// </summary>
    public class StarshipManagerTests
    {
        #region ConsumablesToHours Test Cases

        [Fact]
        public void ConsumablesToHours_InputIsNull_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => StarshipManager.ConsumablesToHours(null));
        }

        [Fact]
        public void ConsumablesToHours_InputIsEmptyString_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => StarshipManager.ConsumablesToHours(string.Empty));
        }

        [Fact]
        public void ConsumablesToHours_InvalidInput_ThrowsFormatException()
        {
            // Assert
            Assert.Throws<FormatException>(() => StarshipManager.ConsumablesToHours("fadfasf"));
        }

        [Fact]
        public void ConsumablesToHours_InputContainsUnknownMetric_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => StarshipManager.ConsumablesToHours("1 second"));
        }

        [Fact]
        public void ConsumablesToHours_ValidInput_ConvertsToHours()
        {
            // Assert
            Assert.Equal((ulong)52560, StarshipManager.ConsumablesToHours("6 years"));
            Assert.Equal((ulong)8760, StarshipManager.ConsumablesToHours("1 year"));
            Assert.Equal((ulong)4320, StarshipManager.ConsumablesToHours("6 months"));
            Assert.Equal((ulong)720, StarshipManager.ConsumablesToHours("1 month"));
            Assert.Equal((ulong)144, StarshipManager.ConsumablesToHours("6 days"));
            Assert.Equal((ulong)24, StarshipManager.ConsumablesToHours("1 day"));
            Assert.Equal((ulong)6, StarshipManager.ConsumablesToHours("6 hours"));
            Assert.Equal((ulong)1, StarshipManager.ConsumablesToHours("1 hour"));
        }

        #endregion

        #region CalculateResupplyCount Test Cases

        [Fact]
        public void CalculateResupplyCount_ValidInputs_ReturnsResupplyCount()
        {
            // Arrange
            ulong expectedResult = 74;
            ulong distance = 1000000;
            string megalight = "80";
            string consumables = "1 week";

            // Act
            ulong actualResult = StarshipManager.CalculateResupplyCount(distance, megalight, consumables);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CalculateResupplyCount_InvalidInputs_ThrowsExceptions()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => StarshipManager.CalculateResupplyCount(0, null, null));
            Assert.Throws<ArgumentNullException>(() => StarshipManager.CalculateResupplyCount(1, null, null));
            Assert.Throws<ArgumentNullException>(() => StarshipManager.CalculateResupplyCount(1, string.Empty, null));
            Assert.Throws<ArgumentNullException>(() => StarshipManager.CalculateResupplyCount(1, null, string.Empty));
            Assert.Throws<ArgumentNullException>(() => StarshipManager.CalculateResupplyCount(1, string.Empty, string.Empty));
            Assert.Throws<FormatException>(() => StarshipManager.CalculateResupplyCount(1, "123456a", "12 seconds"));
            Assert.Throws<ArgumentException>(() => StarshipManager.CalculateResupplyCount(1, "123456", "12 seconds"));
        }

        #endregion
    }
}
