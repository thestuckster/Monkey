namespace Monkey;

public static class TokenTypes
{
    public const string Illegal = "ILLEGAL";
    public const string Eof = "EOF"; //C# doesn't seem to read or care about an EOF character... leaving it here just in case its useful later
    
    private static Dictionary<string, string?> _keywords = new()
    {
        {"fn", Keywords.Function},
        {"let", Keywords.Let}
    };

    /// <summary>
    /// Determine if an identifier is a keyword or not.
    /// </summary>
    /// <param name="word"></param>
    /// <returns>Returns a keyword type if word has a keyword mapping else returns IDENT type</returns>
    public static string LookUpIdentType(string word) =>
    _keywords.TryGetValue(word, out string value)? value : Literals.Ident;
    
    
    /// <summary>
    /// Identifiers and literal token type constants
    /// </summary>
    public static class Literals
    {
        public const string Ident = "IDENT"; //foo, x, y etc.
        public const string Int = "INT"; // 1234
    }

    /// <summary>
    /// Operator token type constants
    /// </summary>
    public static class Operators
    {
        public const string Assign = "=";
        public const string Plus = "+";
    }

    /// <summary>
    /// Supported delimiters 
    /// </summary>
    public static class Delimiters
    {
        public const string Comma = ",";
        public const string Semicolon = ";";

        public const string LParen = "(";
        public const string RParen = ")";

        public const string LBrace = "{";
        public const string RBrace = "}";
    }

    /// <summary>
    /// Reserved keywords in Monkey
    /// </summary>
    public static class Keywords
    {
        public const string Function = "FUNCTION";
        public const string Let = "LET";
    }
}