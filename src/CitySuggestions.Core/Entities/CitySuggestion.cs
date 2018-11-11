namespace CitySuggestions.Core.Entities
{
    public class CitySuggestion : BaseEntity
    {
        public City City { get; set; }
        public double Score { get; set; }
    }
}
