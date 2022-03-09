using System.Text;

namespace Monkey.Parser;

public class ReturnStatement : IStatement
{
    public Token? Token { get; set; } // the 'return' token
    public IExpression? ReturnValue { get; set; }

    public string TokenLiteral() => Token.Literal;

    public override string ToString()
    {
        var builder = new StringBuilder($"{TokenLiteral()} ");
        if (ReturnValue is not null) builder.Append(ReturnValue); //TODO: delete this when we can parse full expressions
        builder.Append(";");

        return builder.ToString();
    }
}