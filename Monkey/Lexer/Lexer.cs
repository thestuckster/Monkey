namespace Monkey;

public class Lexer
{
    private readonly char[] _input;
    
    private int position; //the current char position
    private int readPosition; //the next char position
    private char ch; //current char under examination

    public Lexer(string input)
    {
        _input = input.ToCharArray();
        ReadChar();
    }

    public Token NextToken()
    {
        var token = ch switch
        {
            //ops
            '=' => new Token(TokenTypes.Operators.Assign, ch.ToString()),
            '+' => new Token(TokenTypes.Operators.Plus, ch.ToString()),

            //delims
            ';' => new Token(TokenTypes.Delimiters.Semicolon, ch.ToString()),
            '(' => new Token(TokenTypes.Delimiters.LParen, ch.ToString()),
            ')' => new Token(TokenTypes.Delimiters.RParen, ch.ToString()),
            '{' => new Token(TokenTypes.Delimiters.LBrace, ch.ToString()),
            '}' => new Token(TokenTypes.Delimiters.RBrace, ch.ToString()),
            ',' => new Token(TokenTypes.Delimiters.Comma, ch.ToString()),

            _ => new Token(TokenTypes.Illegal, string.Empty)
        };
        
        //move forward
        ReadChar();

        return token;
    }

    /// <summary>
    /// Gives us the next char and advance our position in the input.
    /// </summary>
    private void ReadChar()
    {
        ch = readPosition >= _input.Length ? '\0' : _input[readPosition];
        position = readPosition;
        readPosition += 1;
    }
    
}
