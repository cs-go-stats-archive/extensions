using System;
using FluentAssertions;
using Xunit;

namespace CSGOStats.Infrastructure.Extensions.Tests
{
    public class ValueExtensionTests
    {
        [Fact]
        public void ClassOfTypeTest()
        {
            object origin = new Sample();
            Record.Exception(() => origin.OfType<Sample>()).Should().BeNull();
        }

        [Fact]
        public void StructureOfTypeTest()
        {
            object origin = 1L;
            Record.Exception(() => origin.OfType<long>()).Should().BeNull();
        }

        [Fact]
        public void DerivedOfTypeTest()
        {
            Base origin = new Derived();
            Derived result = null;
            Record.Exception(() => result = origin.OfType<Base, Derived>()).Should().BeNull();

            result.Should().NotBeNull();
            result.Data.Should().Be(origin.Data);
        }
    }

    public class Base
    {
        public int Data { get; } = new Random().Next();
    }

    public class Derived : Base { }

    public class Sample { }
}