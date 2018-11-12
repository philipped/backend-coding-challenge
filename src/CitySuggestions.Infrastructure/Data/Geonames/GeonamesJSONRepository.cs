using CitySuggestions.Core.Entities;
using CitySuggestions.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CitySuggestions.Infrastructure.Data.Geonames
{
    public class GeonamesJSONRepository : ICityRepository
    {
        public IList<City> GetAllCities()
        {
            var cities = new List<City>();

            try
            {
                cities = JsonConvert.DeserializeObject<List<City>>(File.ReadAllText(@"..\CitySuggestions.Infrastructure\Data\Geonames\cities_canada-usa.json"));
            }
            catch (JsonReaderException ex)
            {
                // TODO: Log Error
            }

            return cities;
        }
    }
}
