using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

namespace CSGOStats.Infrastructure.Extensions.Tests
{
    public class StringParseExtensionTests
    {
        private const string WrongNumericValue = "Abcd";

        private static readonly Random Random = new Random();

        [Fact]
        public void IntParseTests()
        {
            {
                var value = Random.Next();
                var parsed = value.ToString(CultureInfo.DefaultThreadCurrentCulture).Int();
                parsed.Should().Be(value);
            }

            {
                Record.Exception(() => WrongNumericValue.Int()).Should().BeOfType<FormatException>();
            }
        }

        [Fact]
        public void LongParseTests()
        {
            {
                var value = (long) Random.Next();
                var parsed = value.ToString(CultureInfo.DefaultThreadCurrentCulture).Long();
                parsed.Should().Be(value);
            }

            {
                Record.Exception(() => WrongNumericValue.Long()).Should().BeOfType<FormatException>();
            }
        }

        [Fact]
        public void DoubleParseTests()
        {
            {
                var value = Random.NextDouble();
                var parsed = value.ToString(CultureInfo.DefaultThreadCurrentCulture).Double();
                parsed.Should().Be(value);
            }

            {
                const string value = ".5";
                var parsed = value.Double();
                parsed.Should().Be(.5);
            }

            {
                Record.Exception(() => WrongNumericValue.Long()).Should().BeOfType<FormatException>();
            }
        }
    }
}