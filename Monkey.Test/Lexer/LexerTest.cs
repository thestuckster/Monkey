using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Monkey.Test.Lexer;

public class LexerTest
{
    [Test]
    public void Should_Lex_Next_Token()
    {
        var input = "=+(){}";

        var expected = new List<Token>
        {
            new (TokenTypes.Operators.Assign, "="),
            new (TokenTypes.Operators.Plus, "+"),
            new (TokenTypes.Delimiters.LParen, "("),
            new (TokenTypes.Delimiters.RParen, ")"),
            new (TokenTypes.Delimiters.LBrace, "{"),
            new (TokenTypes.Delimiters.RBrace, "}")
        };

        //for some reason this has to be fully qualified...
        var lexer = new Monkey.Lexer(input);
        foreach (var expectedToken in expected)
        {
            var token = lexer.NextToken();
            token.Type.Should().Be(expectedToken.Type);
            token.Literal.Should().Be(expectedToken.Literal);
        }
    }
}