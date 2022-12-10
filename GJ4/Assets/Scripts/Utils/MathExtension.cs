
using System;

namespace GJ4.Utils
{
    public static class MathExtension 
    {
        public static int IntegerPartOfValue(this float value) => (int) Math.Truncate(value);

        public static float FractionalPartOfValue(this float value) => value - IntegerPartOfValue(value);

        public static int RoundOrFloor(this float value) 
        {
            var direction = value < 0 ? -1 : 1;

            return (int)(FractionalPartOfValue(value) < 0.5f * direction ? Math.Floor(value) : Math.Ceiling(value));
        }
    }
}
