using System.Text;

namespace swxben.helpers.StringExtensions
{
    public static class ToSentenceCaseExtension
    {
        public static string ToSentenceCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var sb = new StringBuilder();

            sb.Append(s.Substring(0, 1).ToUpper());
            if (s.Length > 1) sb.Append(s.Substring(1, s.Length - 1));

            return sb.ToString();
        }

        public static string SentenceCase(this string s)
        {
            return ToSentenceCase(s);
        }
    }
}
