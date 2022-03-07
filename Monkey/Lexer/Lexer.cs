using Monkey.Extensions;

namespace Monkey;

public class Lexer
{
    private readonly char[] _input;
    private char _ch; //current char under examination

    private int _position; //the current char position
    private int _readPosition; //the next char position

    public Lexer(string input)
    {
        _input = input.ToCharArray();
        ReadChar();
    }

    public Token NextToken()
    {
        EatWhitespace();

        var token = _ch switch
        {
            //ops
            '=' => DetermineAssignOrEq(),
            '+' => new Token(TokenTypes.Operators.Plus, _ch.ToString()),
            '-' => new Token(TokenTypes.Operators.Minus, _ch.ToString()),
            '*' => new Token(TokenTypes.Operators.Asterisk, _ch.ToString()),
            '/' => new Token(TokenTypes.Operators.Slash, _ch.ToString()),

            '!' => DetermineBangOrNotEq(),
            '<' => new Token(TokenTypes.Operators.Lt, _ch.ToString()),
            '>' => new Token(TokenTypes.Operators.Gt, _ch.ToString()),

            //delims
            ';' => new Token(TokenTypes.Delimiters.Semicolon, _ch.ToString()),
            '(' => new Token(TokenTypes.Delimiters.LParen, _ch.ToString()),
            ')' => new Token(TokenTypes.Delimiters.RParen, _ch.ToString()),
            '{' => new Token(TokenTypes.Delimiters.LBrace, _ch.ToString()),
            '}' => new Token(TokenTypes.Delimiters.RBrace, _ch.ToString()),
            ',' => new Token(TokenTypes.Delimiters.Comma, _ch.ToString()),

            _ => DetermineComplexToken()
        };

        ReadChar();

        return token;
    }

    public bool HasNextToken() => Peek() is not '\0';

    private void EatWhitespace()
    {
        var isWhitespace = _ch is ' ' or '\t' or '\n' or '\r';
        while (isWhitespace)
        {
            ReadChar();
            isWhitespace = _ch is ' ' or '\t' or '\n' or '\r';
        }
    }

    private void ReadChar()
    {
        _ch = _readPosition >= _input.Length ? '\0' : _input[_readPosition];
        _position = _readPosition;
        _readPosition += 1;
    }
    
    private char Peek()
    {
        //this is stupid hacky and I hate it but we HAVE to get the last token out before we stop
        var inputIndexes = _input.Length - 1;
        if (_position == inputIndexes) return _ch;
        return _readPosition > inputIndexes ? '\0' : _input[_readPosition];
    }

    private Token DetermineComplexToken()
    {
        if (_ch.IsAlphaOrUnderscore())
        {
            var literal = ReadIdentifier();
            var type = TokenTypes.LookUpIdentType(literal);
            return new Token(type, literal);
        }

        if (char.IsDigit(_ch))
        {
            var literal = ReadNumber();
            return new Token(TokenTypes.Literals.Int, literal);
        }

        return new Token(TokenTypes.Illegal, _ch.ToString());
    }

    private Token DetermineAssignOrEq()
    {
        var next = Peek();
        if (next is '=')
        {
            var literal = _ch.ToString() + next;
            ReadChar();

            return new Token(TokenTypes.Operators.Eq, literal);
        }

        return new Token(TokenTypes.Operators.Assign, _ch.ToString());
    }

    private Token DetermineBangOrNotEq()
    {
        var next = Peek();
        if (next is '=')
        {
            var literal = _ch.ToString() + next;
            ReadChar();

            return new Token(TokenTypes.Operators.NotEq, literal);
        }

        return new Token(TokenTypes.Operators.Bang, _ch.ToString());
    }
    
    /// <summary>
    /// If the char is alpha or _ lets read the whole word
    /// </summary>
    /// <returns>the whole identifier string</returns>
    private string ReadIdentifier()
    {
        var position = _position;
        while (_ch.IsAlphaOrUnderscore())
            ReadChar();

        var slice = _input.Take(new Range(position, _position)).ToArray();
        var literal = new string(slice);

        StepBack();

        return literal;
    }

    /// <summary>
    /// If the char is a digit, lets read the whole number
    /// </summary>
    /// <returns>a string representation of a whole number</returns>
    private string ReadNumber()
    {
        var position = _position;
        while (char.IsDigit(_ch))
            ReadChar();

        var slice = _input.Take(new Range(position, _position)).ToArray();
        var literal = new string(slice);

        StepBack();

        return literal;
    }

    /// <summary>
    /// Step back in time. Used after reading a 2+ character long identifier.
    /// </summary>
    private void StepBack()
    {
        _position -= 1;
        _readPosition -= 1;
        _ch = _input[_position];
    }

    
}