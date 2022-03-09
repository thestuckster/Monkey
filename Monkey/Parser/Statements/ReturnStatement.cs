namespace Monkey.Parser;

public class ReturnStatement : IStatement
{
    public Token? Token { get; set; } // the 'return' token
    public IExpression? ReturnValue { get; set; }

    public string TokenLiteral() => Token.Literal;
}