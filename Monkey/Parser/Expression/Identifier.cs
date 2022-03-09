namespace Monkey.Parser;

/// <summary>
/// Identifier is an expression because in monkey some parts of an identifier DO produce values.
/// Ex: let x = ValueProducingIdentifier;
///
/// To keep the number of different nodes to a minimum we will use Identifier to represent the name in a variable binding
/// and later reuse it, to represent an identifier as part of, or, as a complete expression.
/// </summary>
public class Identifier : IExpression
{
    public Token Token { get; set; } //the IDENT token
    public string Value { get; set; }
    
    public string TokenLiteral() => Token.Literal;
    
}