namespace Monkey.Parser;

/// <summary>
/// Represents statements that contains expressions.
/// ie: let myVar = anotherVar; let x = 5 * 5; etc.
/// </summary>
public class ExpressionStatement : IStatement
{
    public Token? Token { get; set; }
    public IExpression? Expression { get; set; }

    public string TokenLiteral() => Token?.Literal;

    public override string ToString()
    {
        if (Expression is not null) return Expression.ToString(); //TODO: delete when we can parse full expressions

        return String.Empty;
    }
}