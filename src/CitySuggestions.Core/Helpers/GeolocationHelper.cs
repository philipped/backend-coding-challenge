using CitySuggestions.Core.Entities;
using CitySuggestions.Core.Extensions;
using System;

namespace CitySuggestions.Core.Helpers
{
    public static class GeolocationHelper
    {
        private static readonly double _earthRadius = 6371e3;

        /// <summary>
        /// Calculate the distance between two locations.
        /// Based on the Spherical law of cosines.
        /// https://en.wikipedia.org/wiki/Spherical_law_of_cosines
        /// </summary>
        /// <param name="firstLocation">Coordinate of the first location</param>
        /// <param name="secondLocation">Coordinate of the Second location</param>
        /// <returns>Distance between the two locations</returns>
        public static double GetDistance(Coordinate firstLocation, Coordinate secondLocation)
        {
            if (firstLocation.Latitude == secondLocation.Latitude && firstLocation.Longitude == secondLocation.Longitude)
            {
                return 0;
            }

            return Math.Acos(
                Math.Sin(firstLocation.Latitude.ToRadian()) *
                Math.Sin(secondLocation.Latitude.ToRadian()) +
                Math.Cos(firstLocation.Latitude.ToRadian()) *
                Math.Cos(secondLocation.Latitude.ToRadian()) *
                Math.Cos((secondLocation.Longitude - firstLocation.Longitude).ToRadian())
            ) * _earthRadius;
        }
    }
}
