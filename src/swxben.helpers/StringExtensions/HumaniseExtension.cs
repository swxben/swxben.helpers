using System.Linq;
using System.Text.RegularExpressions;

namespace swxben.helpers.StringExtensions
{
    public static class HumaniseExtension
    {
        static readonly string[] HUMANISE_RECASE_TOLOWER = new[] {
			"a", "and", "as", "for", "to", "in", "from"
		};

        public static string Humanise(this string s)
        {
            s = Regex.Replace(s, @"([A-Z])", match => "_" + match);
            s = s.Replace("_", " ");
            s = s.Trim();
            var split = s.Split(' ');
            var splitRecased = split.Select(t => HUMANISE_RECASE_TOLOWER.Contains(t.ToLower()) ? t.ToLower() : t);
            var unsplit = string.Join(" ", splitRecased.ToArray());
            return unsplit;
        }

        public static string Humanize(this string s)
        {
            return Humanise(s);
        }
    }
}
