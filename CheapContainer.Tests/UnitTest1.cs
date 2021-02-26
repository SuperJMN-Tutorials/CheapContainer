using FluentAssertions;
using System;
using Xunit;

namespace CheapContainer.Tests
{
    // Ciclo de TDD: Test-Driven Design
    // Red, Green, Refactor
    // Si no tienes un test fallando, prohibido escribir código de producción

    public class UnitTest1
    {
        [Fact]
        public void Resolving_interface_myservice_creates_instance_of_myservice()
        {
            var sut = new CheapDependencyContainer();
            sut.Register<IMyService, MyService>();
            var result = sut.Resolve<IMyService>();
            result.Should().BeOfType<MyService>();
        }

        [Fact]
        public void Resolving_interface_myotherservice_creates_instance_of_myotherservice()
        {
            var sut = new CheapDependencyContainer();
            sut.Register<IMyOtherService, MyOtherService>();
            var result = sut.Resolve<IMyOtherService>();
            result.Should().BeOfType<MyOtherService>();
        }
    }

    
}
