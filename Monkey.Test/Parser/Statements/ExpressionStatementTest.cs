using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Monkey.Parser;
using NUnit.Framework;

namespace Monkey.Test.Parser.Statements;

public class ExpressionStatementTest
{
   [Test]
   public void ShouldReturnAStringOfTheProgram()
   {
      var let = new LetStatement
      {
         Token = new Token(TokenTypes.Keywords.Let, "let"),
         Name = new Identifier
         {
            Token = new Token(TokenTypes.Literals.Ident,"myVar"),
            Value = "myVar"
         },
         Value = new Identifier
         {
            Token = new Token(TokenTypes.Literals.Ident, "anotherVar"),
            Value = "anotherVar"
         }
      };


      var statements = new List<IStatement> { let };

      var program = new AProgram
      {
         Statements = statements
      };

      var s = program.ToString();
      s.Should().Be("let myVar = anotherVar;");
   }
   
}