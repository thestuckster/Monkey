using System.Text;

namespace Monkey.Parser;

public class LetStatement : IStatement
{
    public Token? Token { get; set; } //the LET token
    public Identifier? Name { get; set; } //the x in let x = 5;
    public IExpression? Value { get; set; } 

    public string TokenLiteral() => Token.Literal;

    public override string ToString()
    {
        var builder = new StringBuilder($"{TokenLiteral()} {Name} = ");
        if (Value is not null) builder.Append($"{Value}"); //TODO: remove this when we can parse full expressions
        builder.Append(";");
        
        return builder.ToString();
    }
}