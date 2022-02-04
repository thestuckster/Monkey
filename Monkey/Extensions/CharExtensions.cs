namespace Monkey.Extensions;

public static class CharExtensions
{

    public static bool IsAlphaOrUnderscore(this char c) => Char.IsLetter(c) || c == '_';

}