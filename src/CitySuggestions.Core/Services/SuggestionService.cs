using CitySuggestions.Core.Entities;
using CitySuggestions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitySuggestions.Core.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly ICityRepository _repository;

        public SuggestionService(ICityRepository repository)
        {
            _repository = repository;
        }

        public IList<CitySuggestion> GetSuggestion()
        {
            var cities = _repository.GetAllCities();

            return new List<CitySuggestion>
            {
                new CitySuggestion()
                {
                    City = new City() {
                        Id = 12345,
                        Name = "Montreal",
                        Lat = 80.5456,
                        Long = 14.123458,
                        Country = "Canada"
                    },
                    Score = 1
                }
            };
        }
    }
}
