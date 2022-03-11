using Monkey.Extensions;

namespace Monkey.Parser;

public class Parser
{
    public List<string> Errors { get; }

    private readonly Lexer _lexer;

    private Token? _currentToken;
    private Token? _peekToken;

    private readonly Dictionary<string, Func<IExpression>> _prefixParseFunctions;
    private readonly Dictionary<string, Func<IExpression, IExpression>> _infixParseFunctions;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        Errors = new List<string>();

        _prefixParseFunctions = new();
        _infixParseFunctions = new();
        
        //read in two tokens so currentToken and peekToken are both set.
        NextToken();
        NextToken();
    }

    public AProgram ParseProgram()
    {
        var program = new AProgram();

        while (_lexer.HasNextToken())
        {
            var statement = ParseStatement();
            if (statement is not null)
                program.Statements.Add(statement);

            NextToken();
        }

        return program;
    }

    private void NextToken()
    {
        _currentToken = _peekToken;
        _peekToken = _lexer.NextToken();
    }

    private IStatement? ParseStatement()
    {
        return _currentToken.Type switch
        {
            TokenTypes.Keywords.Let => ParseLetStatement(),
            TokenTypes.Keywords.Return => ParseReturnStatement(),
            _ => null
        };
    }

    private IStatement? ParseLetStatement()
    {
        var letStatement = new LetStatement {Token = _currentToken};

        if (!ExpectedPeek(TokenTypes.Literals.Ident)) return null;

        letStatement.Name = new Identifier
        {
            Token = _currentToken,
            Value = _currentToken.Literal
        };

        if (!ExpectedPeek(TokenTypes.Operators.Assign)) return null;

        if (_currentToken.IsSame(TokenTypes.Delimiters.Semicolon))
            NextToken(); //we're skipping expressions until we hit a ;

        return letStatement;
    }

    private IStatement? ParseReturnStatement()
    {
        var statement = new ReturnStatement
        {
            Token = _currentToken
        };
        
        NextToken();
        
        if (_currentToken.IsSame(TokenTypes.Delimiters.Semicolon))
            NextToken(); //we're skipping expressions until we hit a ;

        return statement;
    }
    
    // used to enforce the correctness of the order of tokes by checking the type of the next token.
    private bool ExpectedPeek(string type)
    {
        if (!_peekToken.IsSame(type))
        {
            AddError(type);
            return false;
        }

        NextToken();
        return true;
    }

    /// <summary>
    /// used to add an error when the type of _peekToken doesn't match the expectation.
    /// </summary>
    /// <param name="expectedType">The token we expected _peekToken to be</param>
    private void AddError(string expectedType) =>
        Errors.Add($"Expected next token to be {expectedType} but got {_peekToken.Type} instead");
}