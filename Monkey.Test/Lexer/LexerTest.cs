using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Monkey.Test.Lexer;

public class LexerTest
{
    [Test]
    public void Should_Lex_Simple_Tokens()
    {
        var input = "=+(){}";

        var expected = new List<Token>
        {
            new(TokenTypes.Operators.Assign, "="),
            new(TokenTypes.Operators.Plus, "+"),
            new(TokenTypes.Delimiters.LParen, "("),
            new(TokenTypes.Delimiters.RParen, ")"),
            new(TokenTypes.Delimiters.LBrace, "{"),
            new(TokenTypes.Delimiters.RBrace, "}")
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

    [Test]
    public void Should_Lex_Parentheses()
    {
        var input = @"(3)";
        var expected = new List<Token>
        {
            new(TokenTypes.Delimiters.LParen, "("),
            new(TokenTypes.Literals.Int, "3"),
            new(TokenTypes.Delimiters.RParen, ")")
        };

        var lexer = new Monkey.Lexer(input);
        foreach (var expectedToken in expected)
        {
            var token = lexer.NextToken();
            token.Type.Should().Be(expectedToken.Type);
            token.Literal.Should().Be(expectedToken.Literal);
        }
    }

    [Test]
    public void Should_Lex_SemiColon_After_Literal()
    {
        var input = "4;";
        var expected = new List<Token>
        {
            new(TokenTypes.Literals.Int, "4"),
            new(TokenTypes.Delimiters.Semicolon, ";")
        };

        var lexer = new Monkey.Lexer(input);
        foreach (var expectedToken in expected)
        {
            var token = lexer.NextToken();
            token.Type.Should().Be(expectedToken.Type);
            token.Literal.Should().Be(expectedToken.Literal);
        }
    }

    [Test]
    public void Should_Lex_Small_Program()
    {
        //TODO: just read this from a file.
        var input = @"
        let five = 5;
        let ten = 10;

        let add = fn(x,y) {
            x + y;
        }

        let result = add(five, ten);";

        var expected = new List<Token>
        {
            new(TokenTypes.Keywords.Let, "let"),
            new(TokenTypes.Literals.Ident, "five"),
            new(TokenTypes.Operators.Assign, "="),
            new(TokenTypes.Literals.Int, "5"),
            new(TokenTypes.Delimiters.Semicolon, ";"),
            new(TokenTypes.Keywords.Let, "let"),
            new(TokenTypes.Literals.Ident, "ten"),
            new(TokenTypes.Operators.Assign, "="),
            new(TokenTypes.Literals.Int, "10"),
            new(TokenTypes.Delimiters.Semicolon, ";"),
            new(TokenTypes.Keywords.Let, "let"),
            new(TokenTypes.Literals.Ident, "add"),
            new(TokenTypes.Operators.Assign, "="),
            new(TokenTypes.Keywords.Function, "fn"),
            new(TokenTypes.Delimiters.LParen, "("),
            new(TokenTypes.Literals.Ident, "x"),
            new(TokenTypes.Delimiters.Comma, ","),
            new(TokenTypes.Literals.Ident, "y"),
            new(TokenTypes.Delimiters.RParen, ")"),
            new(TokenTypes.Delimiters.LBrace, "{"),
            new(TokenTypes.Literals.Ident, "x"),
            new(TokenTypes.Operators.Plus, "+"),
            new(TokenTypes.Literals.Ident, "y"),
            new(TokenTypes.Delimiters.Semicolon, ";"),
            new(TokenTypes.Delimiters.RBrace, "}"),
            new(TokenTypes.Delimiters.Semicolon, ";"),
            new(TokenTypes.Keywords.Let, "let"),
            new(TokenTypes.Literals.Ident, "result"),
            new(TokenTypes.Operators.Assign, "="),
            new(TokenTypes.Literals.Ident, "add"),
            new(TokenTypes.Delimiters.LParen, "("),
            new(TokenTypes.Literals.Ident, "five"),
            new(TokenTypes.Delimiters.Comma, ","),
            new(TokenTypes.Literals.Ident, "ten"),
            new(TokenTypes.Delimiters.RParen, ")"),
            new(TokenTypes.Delimiters.Semicolon, ";"),
            new(TokenTypes.Eof, ""),
        };

        var lexer = new Monkey.Lexer(input);
        for (var i = 0; i < expected.Count; i++)
        {
            var expectedToken = expected[i];
            var token = lexer.NextToken();
            token.Type.Should().Be(expectedToken.Type, $"TokenType is different than what was expected at index [{i}]");
            token.Literal.Should().Be(expectedToken.Literal);
        }
    }
}