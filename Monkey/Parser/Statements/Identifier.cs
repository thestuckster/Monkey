using System.Reflection.Metadata.Ecma335;

namespace Monkey.Parser;

public class Identifier : Statement
{
    public Token Token { get; set; }
    public string Value { get; set; }
    public string TokenLiteral() => Token.Literal;
    
}