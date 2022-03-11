namespace Monkey.Parser;

public class IntegerLiteral : IExpression
{
    public Token Token { get; init; }
    public int Value { get; set; }

    public string TokenLiteral() => Token.Literal;

    public override string ToString() => Token.Literal;
}