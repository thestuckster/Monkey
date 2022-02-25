namespace Monkey.Extensions;

public static class TokenExtensions
{
    public static bool IsSame(this Token t, string value) => t.Type.Equals(value);
}