using System.Globalization;
using System.IO;
using System.Linq;

namespace swxben.helpers.StringExtensions
{
    public static class MakeFileNameSafeExtension
    {
        public static string MakeFileNameSafe(this string s)
        {
            return Path
                .GetInvalidFileNameChars()
                .Aggregate(s, (current, c) => current.Replace(c.ToString(CultureInfo.InvariantCulture), string.Empty));
        }
    }
}
