using CitySuggestions.Core.Entities;

namespace CitySuggestions.Core.Interfaces
{
    public interface IScoreService
    {
        double GetScore(City city, string query, double? latitude, double? longitude);
    }
}
