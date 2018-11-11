using CitySuggestions.Core.Entities;
using CitySuggestions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitySuggestions.Infrastructure.Data.Geonames
{
    public class GeonamesRepository : ICityRepository
    {
        public IList<City> GetAllCities()
        {
            return new List<City>
            {
                new City()
                {
                    Id = 12345,
                    Name = "Montreal",
                    Lat = 80.5456,
                    Long = 14.123458,
                    Country = "Canada"
                }
            };
        }
    }
}
