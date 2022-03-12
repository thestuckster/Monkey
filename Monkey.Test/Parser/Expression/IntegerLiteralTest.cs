using FluentAssertions;
using Monkey.Parser;
using NUnit.Framework;

namespace Monkey.Test.Parser.Expression;

public class IntegerLiteralTest
{
    [Test]
    public void ShouldParseIntegerLiteral()
    {
        var input = "5;";

        var lexer = new Monkey.Lexer(input);
        var parser = new Monkey.Parser.Parser(lexer);

        var program = parser.ParseProgram();
        ParserTestHelper.ParserShouldNotHaveErrors(parser);

        program.Statements.Should().NotBeEmpty();
        
        var statement = program.Statements[0];
        statement.Should().NotBeNull();

        var expressionStatement = statement as ExpressionStatement;
        expressionStatement.Should().NotBeNull();
        expressionStatement.Expression.Should().NotBeNull();

        var intLiteral = expressionStatement.Expression as IntegerLiteral;
        intLiteral.Should().NotBeNull();

        intLiteral.Value.Should().Be(5);
        intLiteral.TokenLiteral().Should().Be("5");
    }
}