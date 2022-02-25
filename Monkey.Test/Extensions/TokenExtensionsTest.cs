using FluentAssertions;
using Monkey.Extensions;
using NUnit.Framework;

namespace Monkey.Test.Extensions;

public class TokenExtensionsTest
{
    [Test]
    public void ShouldReturnTrue() => new Token("test", "test").IsSame("test").Should().BeTrue();

    [Test]
    public void ShouldReturnFalse() => new Token("test", "test").IsSame("notATest").Should().BeFalse();

}