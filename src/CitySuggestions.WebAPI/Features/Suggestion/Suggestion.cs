using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CitySuggestions.Core.Interfaces;
using MediatR;

namespace CitySuggestions.WebAPI.Features.Suggestion
{
    public class Suggestion
    {
        public class Model
        {
            public string Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public double Score { get; set; }
        }

        public class Request : IRequest<Response>
        {
            public string Q { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
        }

        public class Response
        {
            public IList<Model> Suggestions { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ISuggestionService _service;
            private readonly IMapper _mapper;

            public Handler(ISuggestionService service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var suggestions = _service.GetSuggestion(request.Q, request.Latitude, request.Longitude);

                return _mapper.Map<Response>(suggestions);
            }

        }

    }
}