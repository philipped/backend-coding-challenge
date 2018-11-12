using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CitySuggestions.WebAPI.Features.Suggestion
{
    [Route("suggestions")]
    public class SuggestionController : Controller
    {
        public IMediator _mediator;

        public SuggestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Suggestion.Request request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}