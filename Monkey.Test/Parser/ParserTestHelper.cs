using FluentAssertions;

namespace Monkey.Test.Parser;

public static class ParserTestHelper
{
    public static void ParserShouldNotHaveErrors(Monkey.Parser.Parser p)
    {
        p.Errors.Should().HaveCount(0);
    }
}