using CitySuggestions.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitySuggestions.Core.Interfaces
{
    public interface ICityRepository
    {
        IList<City> GetAllCities();
    }
}
