using CitySuggestions.Core.Entities;
using CitySuggestions.Core.Extensions;
using CitySuggestions.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CitySuggestions.Core.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly ICityRepository _repository;
        private readonly IScoreService _service;

        public SuggestionService(ICityRepository repository, IScoreService service)
        {
            _repository = repository;
            _service = service;
        }

        public void temp()
        {
            var _city = new City()
            {
                Id = 123,
                Name = "New York City",
                Country = "USA",
                State = "NY",
                Lat = 40.71427,
                Long = -74.00597
            };
            var query = "New York City";
            double? latitude = 40.71427;
            double? longitude = -74.00597;

            var result = _service.GetScore(_city, query, latitude, longitude);
        }

        /// <summary>
        /// Get a list of suggested cities based on searched keywords and coordinates
        /// </summary>
        /// <param name="query">Searched keywords</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns>List of suggested cities</returns>
        public IList<CitySuggestion> GetSuggestion(string query, double? latitude, double? longitude)
        {
            var allCities = _repository.GetAllCities();

            temp();

            return allCities.Where(c => c.Name.ToSearchableText()
                            .Contains(query.ToSearchableText()))
                            .Select(c => new CitySuggestion
                            {
                                City = c,
                                Score = _service.GetScore(c, query, latitude, longitude)
                            })
                            .OrderBy(c => c.City.Name.StartsWith(query) ? 0 : 1)
                            .OrderByDescending(c => c.Score)
                            .ToList();
        }
    }
}
