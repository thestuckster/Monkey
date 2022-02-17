namespace Monkey.Parser;

public class LetStatement : Statement
{
    public Token Token { get; set; } //the LET token
    public Identifier Name { get; set; } //the x in let x = 5;
    public Expression Value { get; set; } // the 

    public string TokenLiteral() => Token.Literal;
}