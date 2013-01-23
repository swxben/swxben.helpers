using System.Globalization;

namespace swxben.helpers.DecimalExtensions
{
    public static class FormatCompactExtension
    {
        static public string FormatCompact(this decimal d, int minDecimalPlaces = 2)
        {
            if (d == 0) return "0." + new string('0', minDecimalPlaces);

            var s = d.ToString(CultureInfo.InvariantCulture);
            int indexOfPeriod = s.IndexOf('.');

            if (indexOfPeriod == -1)
            {
                if (minDecimalPlaces > 0) s += "." + new string('0', minDecimalPlaces);
                return s;
            }

            s = s.TrimEnd('0');

            if (minDecimalPlaces <= 0) return s.TrimEnd('.');

            int numToPad = minDecimalPlaces - (s.Length - (indexOfPeriod + 1));
            if (numToPad > 0) s += new string('0', numToPad);
            return s;
        }
    }
}
