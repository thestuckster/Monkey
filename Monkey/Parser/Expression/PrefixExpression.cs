using System.Text;

namespace Monkey.Parser;

public class PrefixExpression : IExpression
{
    public Token Token { get; init; }
    public string Operator { get; init; }

    public IExpression Right { get; set; }
    
    public string TokenLiteral() => Token.Literal;

    public override string ToString()
    {
        var builder = new StringBuilder("(");
        builder.Append(Operator);
        builder.Append(Right);
        builder.Append(")");
        return builder.ToString();
    }
}