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
            result.Should().BeAssignableTo<IMyService>();
        }

        [Fact]
        public void Resolving_interface_myotherservice_creates_instance_of_myotherservice()
        {
            var sut = new CheapDependencyContainer();
            sut.Register<IMyOtherService, MyOtherService>();
            var result = sut.Resolve<IMyOtherService>();
            result.Should().BeAssignableTo<IMyOtherService>();
        }

        [Fact]
        public void Resolving_interface_myotherservice_creates_specific_instance_of_myotherservice()
        {
            var sut = new CheapDependencyContainer();
            sut.Register<IMyOtherService, MyOtherService>();
            var result = sut.Resolve<IMyOtherService>();
            result.Name.Should().BeNull();
        }

        [Fact]
        public void Resolving_interface_of_complex_type()
        {
            var sut = new CheapDependencyContainer();
            sut.Register<IMyOtherService, MyOtherService>();
            sut.Register<IMyComplexService, MyComplexService>();
            var result = sut.Resolve<IMyComplexService>();
            result.Should().BeAssignableTo<IMyComplexService>();
        }
    }
}
