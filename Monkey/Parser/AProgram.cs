namespace Monkey.Parser;

/// <summary>
/// The root node of every AST our parser produces
/// </summary>
public class AProgram : INode
{
    /// <summary>
    /// Every valid Monkey program is a series of statements. They are contained here. This is really just a slice of
    /// AST nodes that implement the Statement interface
    /// </summary>
    public List<Statement> Statements { get; set; }

    public string TokenLiteral()
    {
        if (Statements.Count > 0) return Statements[0].TokenLiteral();
        return "";
    }
}