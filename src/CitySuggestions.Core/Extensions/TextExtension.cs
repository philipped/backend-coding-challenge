namespace CitySuggestions.Core.Extensions
{
    public static class TextExtension
    {
        public static string ToSearchableText(this string text)
        {
            return text.ToLowerInvariant().Replace(" ", string.Empty);
        }
    }
}
