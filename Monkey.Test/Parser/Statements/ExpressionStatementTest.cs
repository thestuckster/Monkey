using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Monkey.Test.Parser.Statements;

public class ExpressionStatementTest
{
    [Test]
    public void ShouldParseExpressionStatement()
    {
        var input = File.ReadAllText("Programs/expressionStatementTest.monk");
        input.Should().NotBeNullOrEmpty();
    }
}