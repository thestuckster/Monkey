using FluentAssertions;
using Monkey.Parser;
using NUnit.Framework;

namespace Monkey.Test.Parser.Expression;

public class ExpressionTest
{
    [Test]
    public void ShouldParseIdentifierExpressions()
    {
        var input = "foobar ;";

        var lexer = new Monkey.Lexer(input);
        var parser = new Monkey.Parser.Parser(lexer);
        
        var program = parser.ParseProgram();
        ParserTestHelper.ParserShouldNotHaveErrors(parser);

        var statements = program.Statements;
        statements.Should().NotBeEmpty();

        var statement = statements[0];
        statement.Should().NotBeNull();

        var expressionStatement = statement as ExpressionStatement;
        expressionStatement.Should().NotBeNull();
        expressionStatement.Expression.Should().NotBeNull();

        var identifierStatement = expressionStatement.Expression as Identifier;
        identifierStatement.Should().NotBeNull();

        identifierStatement.Value.Should().Be("foobar");
        identifierStatement.TokenLiteral().Should().Be("foobar");
    }
}