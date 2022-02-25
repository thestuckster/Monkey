using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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
        program.Should().NotBeNull();

        program.Statements.Should().HaveCount(3);

        var expectedIds = new List<string>
        {
            "x", "y", "foobar"
        };

        for (var i = 0; i < program.Statements.Count; i++)
        {
            var statement = program.Statements[i];
            statement.TokenLiteral().ToLower().Should().Be("let");

            var letStatement = statement as LetStatement;
            letStatement.Should().NotBeNull("Could not convert statement into a LetStatement!");

            letStatement.Name.Value.Should().Be(expectedIds[i]);
            letStatement.TokenLiteral().Should().Be(expectedIds[i]);

        }
    }
}