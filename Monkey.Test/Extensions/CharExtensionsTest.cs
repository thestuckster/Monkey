using FluentAssertions;
using Monkey.Extensions;
using NUnit.Framework;

namespace Monkey.Test.Extensions;

public class CharExtensionsTest
{

    [TestCase('a')]
    [TestCase('A')]
    [TestCase('_')]
    public void Should_Return_True(char c)
    {
        c.IsAlphaOrUnderscore().Should().BeTrue();
    }

    [Test]
    public void Should_Return_False()
    {
        var c = '8';
        c.IsAlphaOrUnderscore().Should().BeFalse();
    }
    
}