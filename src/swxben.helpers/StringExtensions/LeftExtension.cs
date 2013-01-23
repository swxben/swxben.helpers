namespace swxben.helpers.StringExtensions
{
    public static class LeftExtension
    {
        public static string Left(this string s, int count)
        {
            return s.Length < count ? s : s.Substring(0, count);
        }
    }
}
