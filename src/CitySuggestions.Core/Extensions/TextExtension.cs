using System.Globalization;
using System.Linq;
using System.Text;

namespace CitySuggestions.Core.Extensions
{
    public static class TextExtension
    {
        public static string ToSearchableText(this string text)
        {
            return text.ToLowerInvariant().RemoveDiacritics().Replace(" ", string.Empty);
        }

        public static string RemoveDiacritics(this string text)
        {
            return string.Concat(text.Normalize(NormalizationForm.FormD).Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)).Normalize(NormalizationForm.FormC);
        }
    }
}
