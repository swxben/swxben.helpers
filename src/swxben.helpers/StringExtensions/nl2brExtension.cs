using System;

namespace swxben.helpers.StringExtensions
{
    public static class nl2brExtension
    {
        public static string nl2br(string value)
        {
            return value.Replace(Environment.NewLine, "<br/>");
        }
    }
}
