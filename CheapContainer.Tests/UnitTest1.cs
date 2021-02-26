using FluentAssertions;
using System;
using Xunit;

namespace CheapContainer.Tests
{
    // Ciclo de TDD: Test-Driven Design
    // Red, Green, Refactor

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new CheapDependencyContainer();
            sut.Register<IMyService, MyService>();
            var result = sut.Resolve<IMyService>();
            result.Should().BeOfType<MyService>();
        }
    }
}
