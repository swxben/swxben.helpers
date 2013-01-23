using System;
using System.Text;

namespace swxben.helpers.StringExtensions
{
    public static class EncodeEmailAddressExtension
    {
        static public string EncodeEmailAddress(this string address)
        {
            var rand = new Random();
            var sb = new StringBuilder();
            foreach (var t in address)
            {
                var r = rand.Next(0, 100);
                if (r > 90 && t != '@') sb.Append(t);
                else if (r < 45) sb.AppendFormat("&#x{0:x};", (int)t);
                else sb.AppendFormat("&#{0:d};", (int)t);
            }
            return sb.ToString();
        }
    }
}
