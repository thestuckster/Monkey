using System.Text.RegularExpressions;
using Monkey.Extensions;

namespace Monkey;

public class Lexer
{
    private readonly char[] _input;

    private int _position; //the current char position
    private int _readPosition; //the next char position
    private char _ch; //current char under examination

    public Lexer(string input)
    {
        //we don't care about whitespace so remove it before setting the input
        _input = input.ToCharArray();
        
        ReadChar();
    }

    public Token NextToken()
    {
        var token = _ch switch
        {
            //ops
            '=' => new Token(TokenTypes.Operators.Assign, _ch.ToString()),
            '+' => new Token(TokenTypes.Operators.Plus, _ch.ToString()),

            //delims
            ';' => new Token(TokenTypes.Delimiters.Semicolon, _ch.ToString()),
            '(' => new Token(TokenTypes.Delimiters.LParen, _ch.ToString()),
            ')' => new Token(TokenTypes.Delimiters.RParen, _ch.ToString()),
            '{' => new Token(TokenTypes.Delimiters.LBrace, _ch.ToString()),
            '}' => new Token(TokenTypes.Delimiters.RBrace, _ch.ToString()),
            ',' => new Token(TokenTypes.Delimiters.Comma, _ch.ToString()),

            _ => DetermineIllegalOrIdentifier()
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
        _ch = _readPosition >= _input.Length ? '\0' : _input[_readPosition];
        _position = _readPosition;
        _readPosition += 1;
    }

    private Token DetermineIllegalOrIdentifier()
    {
        if (_ch.IsAlphaOrUnderscore())
        {
            var literal = ReadIdentifier();
            var type = TokenTypes.LookUpIdentType(literal);
            return new Token(type, literal);
        }

        return new Token(TokenTypes.Illegal, _ch.ToString());
    }

    /// <summary>
    /// If the char is alpha or _ lets read the whole word
    /// </summary>
    /// <returns>the whole identifier string</returns>
    private string ReadIdentifier()
    {
        var position = _position;
        while (_ch.IsAlphaOrUnderscore())
        {
            ReadChar();
        }

        var range = new Range(position, _position);
        var slice = _input.Take(range).ToArray();
        return new string(slice);
    }
}