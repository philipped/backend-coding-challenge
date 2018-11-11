namespace CitySuggestions.Core.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Country { get; set; }
    }
}
