using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Monkey.Test.Parser.Statements;

public class ReturnStatementTest
{
    // [Test]
    // public void ShouldParseReturnStatements()
    // {
    //     var input = File.ReadAllText("Programs/returnStatementTest.monk");
    //     input.Should().NotBeNullOrEmpty();
    //
    //     var lexer = new Monkey.Lexer(input);
    //     var parser = new Monkey.Parser.Parser(lexer);
    //
    //     var program = parser.ParseProgram();
    //     ParserTestHelper.ParserShouldNotHaveErrors(parser);
    //     
    //     program.Should().NotBeNull();
    //     program.Statements.Should().HaveCount(3);
    //     
    //     
    //     
    // }
}