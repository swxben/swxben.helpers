using System;
using System.Security.Cryptography;
using System.Text;

namespace swxben.helpers.StringExtensions
{
    public static class HashSHA256Extension
    {
        public static string HashSHA256(this string input)
        {
            return Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(input ?? "")));
        }
    }
}
