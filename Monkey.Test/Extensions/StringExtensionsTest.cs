using FluentAssertions;
using Monkey.Extensions;
using NUnit.Framework;

namespace Monkey.Test.Extensions;

public class StringExtensionsTest
{
    [Test]
    public void Should_Remove_Whitespace()
    {
        var s = "this is a test";
        s.RemoveWhiteSpace().Should().Be("thisisatest");
    }
}