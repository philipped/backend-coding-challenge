using CitySuggestions.Core.Entities;
using CitySuggestions.Core.Helpers;
using Xunit;

namespace CitySuggestions.UnitTests.Core
{
    public class GeolocationHelperTests
    {
        private readonly City _newYork;
        private readonly City _montreal;

        public GeolocationHelperTests()
        {
            _newYork = new City()
            {
                Id = 123,
                Name = "New York City",
                Country = "USA",
                State = "NY",
                Lat = 40.71427,
                Long = -74.00597
            };

            _montreal = new City()
            {
                Id = 456,
                Name = "Montréal",
                Country = "Canada",
                State = "QC",
                Lat = 45.50884,
                Long = -73.5878
            };
        }

        [Fact]
        public void distanceBetweenMontrealAndNewyorkShouldBe535km()
        {
            var montrealCoord = new Coordinate()
            {
                Latitude = _montreal.Lat,
                Longitude = _montreal.Long
            };

            var newyorkCoord = new Coordinate()
            {
                Latitude = _newYork.Lat,
                Longitude = _newYork.Long
            };

            var result = GeolocationHelper.GetDistance(montrealCoord, newyorkCoord);
            var expected = 534209.131234364;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void distanceBetweenNewyorkAndNewyorkShouldBe0()
        {
            var newyorkCoord = new Coordinate()
            {
                Latitude = _newYork.Lat,
                Longitude = _newYork.Long
            };

            var result = GeolocationHelper.GetDistance(newyorkCoord, newyorkCoord);
            var expected = 0;

            Assert.Equal(expected, result);
        }
    }
}
