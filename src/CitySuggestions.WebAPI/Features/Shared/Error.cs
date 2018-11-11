using System.Collections.Generic;

namespace CitySuggestions.WebAPI.Features.Shared
{
    public class Error
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public IList<ErrorDetails> Details { get; set; }
    }
}
