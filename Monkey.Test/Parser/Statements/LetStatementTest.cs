using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Monkey.Parser;
using NUnit.Framework;

namespace Monkey.Test.Parser.Statements;

public class LetStatementTest
{
    [Test]
    public void ShouldParseLetStatements()
    {
        var input = File.ReadAllText("Programs/letStatementTest.monk");
        input.Should().NotBeNullOrEmpty();

        var lexer = new Monkey.Lexer(input);
        var parser = new Monkey.Parser.Parser(lexer);

        var program = parser.ParseProgram();
        ParserTestHelper.ParserShouldNotHaveErrors(parser);
        
        program.Should().NotBeNull();
        program.Statements.Should().HaveCount(3);

        var expectedIds = new List<string>
        {
            "x", "y", "foobar"
        };

        for (var i = 0; i < program.Statements.Count; i++)
        {
            AssertLetStatements(program.Statements[i], expectedIds[i]);
        }
    }

    [Test]
    public void ShouldReportErrors()
    {
        var input = File.ReadAllText("Programs/letStatementError.monk");
        input.Should().NotBeNullOrEmpty();

        var lexer = new Monkey.Lexer(input);
        var parser = new Monkey.Parser.Parser(lexer);

        parser.ParseProgram();
        ParserTestHelper.ParserShouldHaveErrors(parser, 1);
    }
    
    private void AssertLetStatements(Statement statement, string name)
    {
        statement.TokenLiteral().ToLower().Should().Be("let");

        var letStatement = statement as LetStatement;
        letStatement.Should().NotBeNull("Could not convert Statement into LetStatement");

        letStatement.Name.Value.Should().Be(name);
        letStatement.Name.TokenLiteral().Should().Be(name);
    }
}