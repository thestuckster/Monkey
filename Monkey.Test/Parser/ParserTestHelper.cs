using System;
using System.Linq;
using FluentAssertions;

namespace Monkey.Test.Parser;

public static class ParserTestHelper
{
    public static void ParserShouldNotHaveErrors(Monkey.Parser.Parser p)
    {
        if (p.Errors.Any())
        {
            Console.WriteLine("Errors: ");
            p.Errors.ForEach(Console.WriteLine);
        }

        p.Errors.Should().BeEmpty();
    }

    public static void ParserShouldHaveErrors(Monkey.Parser.Parser p, int numberOfErrors) =>
        p.Errors.Should().HaveCount(numberOfErrors);

}