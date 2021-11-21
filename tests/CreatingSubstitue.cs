using System;
using NSubstitute;
using Xunit;

namespace UsingNSubstitute
{
    public class CreatingSubstitue
    {
        ICommand command = Substitute.For<ICommand, IDisposable>();

        [Fact]
        public void Teste1()
        {
            var runner = new CommandRunner(command);

            runner.RunCommand();
            command.Received().Execute();
            ((IDisposable)command).Received().Dispose();
        }

        [Fact]
        public void Teste2()
        {
            var func = Substitute.For<Func<string>>();
            func().Returns("hello");

            Assert.Equal("hello", func());
        }
    }
    
}