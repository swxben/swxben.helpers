using System.Collections.Generic;
using System.IO;

namespace swxben.helpers.StringExtensions
{
    public static class LinesExtension
    {
        public static IEnumerable<string> Lines(this string s)
        {
            using (var reader = new StringReader(s))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
