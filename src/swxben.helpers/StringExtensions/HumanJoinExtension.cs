using System.Text;

namespace swxben.helpers.StringExtensions
{
    public static class HumanJoinExtension
    {
        public static string HumanJoin(this string[] s)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (i != 0)
                {
                    sb.Append(i < s.Length - 1 ? ", " : " and ");
                }
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
    }
}
