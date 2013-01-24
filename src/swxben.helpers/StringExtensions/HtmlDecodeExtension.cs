namespace swxben.helpers.StringExtensions
{
    public static class HtmlDecodeExtension
    {
        public static string HtmlDecode(this string s)
        {
            return System.Net.WebUtility.HtmlDecode(s);
        }
    }
}
