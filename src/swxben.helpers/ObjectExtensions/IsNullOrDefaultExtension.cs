using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace swxben.helpers.ObjectExtensions
{
    public static class IsNullOrDefaultExtension
    {
        public static bool IsNullOrDefault<T>(this T value)
        {
            return object.Equals(default(T), value);
        }
    }
}
