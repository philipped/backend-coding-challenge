using FluentValidation;

namespace CitySuggestions.WebAPI.Features.Suggestion
{
    public class SuggestionValidator : AbstractValidator<Suggestion.Request>
    {
        public SuggestionValidator()
        {
            RuleFor(suggestion => suggestion.Q)
                .NotEmpty();

            RuleFor(suggestion => suggestion.Latitude)
                .GreaterThan(-91)
                .LessThan(91);

            RuleFor(suggestion => suggestion.Longitude)
                .GreaterThan(-181)
                .LessThan(181);
        }
    }
}
