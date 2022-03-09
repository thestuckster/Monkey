namespace Monkey.Parser;

public class ExpressionStatement : IStatement
{
    public Token? Token { get; set; }
    public IExpression? Expression { get; set; }
    
    public string TokenLiteral()
    {
        throw new NotImplementedException();
    }
}