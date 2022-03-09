namespace Monkey.Parser;

public class ExpressionStatement : IStatement
{
    public Token? Token { get; set; }
    public Expression? Expression { get; set; }
    
    public string TokenLiteral()
    {
        throw new NotImplementedException();
    }
}