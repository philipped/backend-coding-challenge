using System;

namespace CitySuggestions.Core.Extensions
{
    public static class MathExtension
    {
        public static double ToRadian(this double degrees)
        {
            return (degrees * Math.PI) / 180;
        }
    }
}
