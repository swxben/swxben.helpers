namespace swxben.helpers.StringExtensions
{
    public static class HtmlEncodeExtension
    {
        public static string HtmlEncode(this string s)
        {
            return System.Net.WebUtility.HtmlEncode(s);
        }
    }
}
