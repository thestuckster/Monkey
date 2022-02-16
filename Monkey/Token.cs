namespace Monkey;

[Serializable]
public class Token
{
    //Should be a value from TokenTypes constants.
    public string Type { get; }
    
    public string Literal { get; }

    public Token(string type, string literal)
    {
        Type = type;
        Literal = literal;
    }

    public override string ToString() => $"[Type [{Type}] - Literal [{Literal}]]";
}