using System.Reflection.Metadata.Ecma335;
using Monkey.Extensions;

namespace Monkey.Parser;

public class Parser
{
    private readonly Lexer _lexer;
    
    private Token _currentToken;
    private Token _peekToken;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        
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

    private Statement? ParseStatement()
    {
        return _currentToken.Type switch
        {
            TokenTypes.Keywords.Let => ParseLetStatement(),
            _ => null,
        };
    }

    private Statement? ParseLetStatement()
    {
        var letStatement = new LetStatement { Token = _currentToken };

        if (!ExpectedPeek(TokenTypes.Literals.Ident)) return null;

        letStatement.Name = new Identifier
        {
            Token = _currentToken,
            Value = _currentToken.Literal
        };

        if (!ExpectedPeek(TokenTypes.Operators.Assign)) return null;
        
        if(!ExpectedPeek(TokenTypes.Delimiters.Semicolon)) NextToken(); //we're skipping expressions until we hit a ;

        return letStatement;
    }

    private bool ExpectedPeek(string type)
    {
        if (!_peekToken.IsSame(type)) return false;
        
        NextToken();
        return true;
    }
    
}