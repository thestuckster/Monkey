using System.Text.RegularExpressions;

namespace Monkey.Extensions;

public static class StringExtensions
{
    public static string RemoveWhiteSpace(this string s) => Regex.Replace(s, @"\s+", "");
    
}