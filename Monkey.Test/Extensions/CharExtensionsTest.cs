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

    [TestCase('8')]
    [TestCase(';')]
    [TestCase('~')]
    public void Should_Return_False(char c)
    {
        c.IsAlphaOrUnderscore().Should().BeFalse();
    }
    
}