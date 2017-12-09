using System;

using Cake.Core;
using Cake.NDepend.Exceptions;

using FluentAssertions;

using Moq;

using Xunit;

namespace Cake.NDepend.Tests.Unit
{
    public sealed class WhenAnalyseNDependProject
    {
        [Fact]
        public void GivenNullCakeContext_ThrowsArgumentNullException()
        {
            var exception = Record.Exception(() => NDependAliases.NDependAnalyse(null, new NDependSettings()));

            exception.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)exception)?.ParamName.Should().Be("context");
        }

        [Fact]
        public void GivenNullNDependSettings_ThrowsArgumentNullException()
        {
            var cakeContextMock = new Mock<ICakeContext>();
            var exception = Record.Exception(() => cakeContextMock.Object.NDependAnalyse(null));

            exception.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)exception)?.ParamName.Should().Be("settings");
        }

        [Fact]
        public void GivenInvalidProjectPath_ThrowsNDependSettingsOptionException()
        {
            var cakeContextMock = new Mock<ICakeContext>();
            var exception = Record.Exception(() => cakeContextMock.Object.NDependAnalyse(new NDependSettings()));

            exception.Should().BeOfType<NDependSettingsOptionException>();
        }
    }
}