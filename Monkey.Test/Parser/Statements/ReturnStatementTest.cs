using System.IO;
using FluentAssertions;
using Monkey.Parser;
using NUnit.Framework;

namespace Monkey.Test.Parser.Statements;

public class ReturnStatementTest
{
    [Test]
    public void ShouldParseReturnStatements()
    {
        var input = File.ReadAllText("Programs/returnStatementTest.monk");
        input.Should().NotBeNullOrEmpty();
    
        var lexer = new Monkey.Lexer(input);
        var parser = new Monkey.Parser.Parser(lexer);
    
        var program = parser.ParseProgram();
        ParserTestHelper.ParserShouldNotHaveErrors(parser);
        
        program.Should().NotBeNull();
        
        //TODO: ALL OR OUR RETURN STATEMENTS ARE OFF BY ONE!!! WTF
        program.Statements.Should().HaveCount(3);

        foreach (var statement in program.Statements)
        {
            var returnStatement = statement as ReturnStatement;
            returnStatement.Should().NotBeNull("Could not cast Statement to ReturnStatement");
            
            returnStatement?.TokenLiteral().Should().Be("return");
        }
    }
}