namespace Monkey.Parser;

public class LetStatement : Statement
{
    public Token Token { get; set; }
    public Identifier Name { get; set; }
    public Expression Value { get; set; }

    public string TokenLiteral() => Token.Literal;
}