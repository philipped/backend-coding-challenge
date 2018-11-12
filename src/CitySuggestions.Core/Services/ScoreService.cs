using CitySuggestions.Core.Entities;
using CitySuggestions.Core.Extensions;
using CitySuggestions.Core.Helpers;
using CitySuggestions.Core.Interfaces;
using System;

namespace CitySuggestions.Core.Services
{
    public class ScoreService : IScoreService
    {
        /// <summary>
        /// Calculate the score of a city based on the searched keywords.
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <param name="keywords">Searched keywords</param>
        /// <returns>City score based on the searched keywords</returns>
        private double GetKeywordsScore(string cityName, string keywords)
        {
            return (double) keywords.ToSearchableText().Length / (double) cityName.ToSearchableText().Length;
        }


        /// <summary>
        /// Calculate the score of a city based on the searched coordinates.
        /// </summary>
        /// <param name="city">City</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns>City score based on the searched coordinates</returns>
        private double GetCoordinateScore(City city, double latitude, double longitude)
        {
            var firstLocation = new Coordinate()
            {
                Latitude = city.Lat,
                Longitude = city.Long
            };

            var secondLocation = new Coordinate()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            var distance = GeolocationHelper.GetDistance(firstLocation, secondLocation);
            var farthestDistance = 1500000;

            return distance < farthestDistance
                ? (farthestDistance - distance) / farthestDistance
                : 0;
        }


        /// <summary>
        /// Calculate the score of a city based on the search keywords and coordinates.
        /// </summary>
        /// <param name="city">City</param>
        /// <param name="query">Searched keywords</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns>City score based on the searched keywords and coordinates</returns>
        public double GetScore(City city, string query, double? latitude, double? longitude)
        {
            var keywordsScore = GetKeywordsScore(city.Name, query);

            if (latitude.HasValue == true && longitude.HasValue == true)
            {
                var geolocationScore = GetCoordinateScore(city, latitude.Value, longitude.Value);

                return Math.Round((keywordsScore + geolocationScore) / 2, 1);
            }

            return Math.Round(keywordsScore, 1);
        }
    }
}
