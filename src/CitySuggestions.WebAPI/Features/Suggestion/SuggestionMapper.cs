using AutoMapper;
using CitySuggestions.Core.Entities;
using System.Collections.Generic;

namespace CitySuggestions.WebAPI.Features.Suggestion
{
    public class SuggestionMapper : Profile
    {
        public SuggestionMapper()
        {
            CreateMap<IList<CitySuggestion>, Suggestion.Response>()
                .ForMember(dest => dest.Suggestions, opts => opts.MapFrom(src => src));

            CreateMap<CitySuggestion, Suggestion.Model>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => string.Format("{0}, {1}, {2}", src.City.Name, src.City.State, src.City.Country)))
                .ForMember(dest => dest.Latitude, opts => opts.MapFrom(src => src.City.Lat))
                .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.City.Long))
                .ForMember(dest => dest.Score, opts => opts.MapFrom(src => src.Score));
        }
    }
}
