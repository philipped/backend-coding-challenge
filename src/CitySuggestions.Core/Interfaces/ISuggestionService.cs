using CitySuggestions.Core.Entities;
using System.Collections.Generic;

namespace CitySuggestions.Core.Interfaces
{
    public interface ISuggestionService
    {
        IList<CitySuggestion> GetSuggestion();
    }
}
