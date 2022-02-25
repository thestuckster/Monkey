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
            Console.WriteLine("blahblahblahblah");
        }
        
        return program;
    }
    
    private void NextToken()
    {
        _currentToken = _peekToken;
        _peekToken = _lexer.NextToken();
    }

}