using FluentAssertions;
using Monkey.Parser;
using NUnit.Framework;

namespace Monkey.Test.Parser.Expression;

public class PrefixExpressionTest
{
    [TestCase("!5;", "!", 5)]
    [TestCase("-15;", "-", 15)]
    public void ShouldParsePrefixOperators(string input, string op, int val)
    {
        var lexer = new Monkey.Lexer(input);
        var parser = new Monkey.Parser.Parser(lexer);

        var program = parser.ParseProgram();
        ParserTestHelper.ParserShouldNotHaveErrors(parser);

        program.Statements.Should().NotBeNull();

        var statement = program.Statements[0];
        statement.Should().NotBeNull();

        var expression = statement as ExpressionStatement;
        expression.Should().NotBeNull();

        var prefix = expression.Expression as PrefixExpression;
        prefix.Should().NotBeNull();

        prefix.Operator.Should().Be(op);

        AssertIntegerLiteral(expression.Expression, val);
    }

    private void AssertIntegerLiteral(IExpression expression, int value)
    {
        var literal = expression as IntegerLiteral;
        literal.Value.Should().Be(value);
        literal.TokenLiteral().Should().Be(value.ToString());
    }
}