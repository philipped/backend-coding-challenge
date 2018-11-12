using CitySuggestions.Core.Interfaces;
using CitySuggestions.Core.Services;
using CitySuggestions.Core.Entities;
using Xunit;

namespace CitySuggestions.UnitTests.Core
{
    public class ScoreServiceTests
    {
        private readonly IScoreService _scoreService;
        private readonly City _city;

        public ScoreServiceTests()
        {
            _scoreService = new ScoreService();
            _city = new City()
            {
                Id = 123,
                Name = "New York City",
                Country = "USA",
                State = "NY",
                Lat = 40.71427,
                Long = -74.00597
            };
        }

        [Fact]
        public void ShouldGivePerfectScoreForCorrectName()
        {
            var query = "New York City";
            var result = _scoreService.GetScore(_city, query, null, null);
            var expected = 1;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldGiveHalfTheScoreForHalfTheName()
        {
            var query = "New Yor";
            var result = _scoreService.GetScore(_city, query, null, null);
            var expected = 0.5;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldGiveZeroScoreForIncorrectName()
        {
            var query = "";
            var result = _scoreService.GetScore(_city, query, null, null);
            var expected = 0;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldGivePerfectScoreForCorrectNameAndCoordinate()
        {
            var query = "New York City";
            var latitude = 40.71427;
            var longitude = -74.00597;

            var result = _scoreService.GetScore(_city, query, latitude, longitude);
            var expected = 1;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldGiveHalfTheScoreForCorrectNameAndIncorectCoordinate()
        {
            var query = "New York City";
            var latitude = 20.71427;
            var longitude = -24.00597;

            var result = _scoreService.GetScore(_city, query, latitude, longitude);
            var expected = 0.5;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldGiveHighScoreForCorrectNameAndNearCoordinate()
        {
            var query = "New York City";
            var latitude = 35.71427;
            var longitude = -70.00597;

            var result = _scoreService.GetScore(_city, query, latitude, longitude);
            var expected = 0.8;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldGiveAverageScoreForHalfTheNameAndNearCoordinate()
        {
            var query = "New Yo";
            var latitude = 35.71427;
            var longitude = -70.00597;

            var result = _scoreService.GetScore(_city, query, latitude, longitude);
            var expected = 0.5;

            Assert.Equal(expected, result);
        }
    }
}
