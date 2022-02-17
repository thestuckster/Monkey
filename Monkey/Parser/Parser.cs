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

    public AProgram ParseAProgram()
    {
        return null;
    }
    
    private void NextToken()
    {
        _currentToken = _peekToken;
        _peekToken = _lexer.NextToken();
    }

}