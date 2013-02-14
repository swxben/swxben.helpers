using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace swxben.helpers.StringExtensions
{
    public static class SafeReplaceExtension
    {
        public static string SafeReplace(this string s, char oldChar, char newChar)
        {
            return ReferenceEquals(s, null) ? null : s.Replace(oldChar, newChar);
        }

        public static string SafeReplace(this string s, string oldValue, string newValue)
        {
            return ReferenceEquals(s, null) ? null : s.Replace(oldValue, newValue);
        }
    }
}
