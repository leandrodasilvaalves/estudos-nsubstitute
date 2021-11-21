using NSubstitute;
using Xunit;

namespace UsingNSubstitute
{
    public class CheckingReceivedCall
    {
        [Fact]
        public void Teste1()
        {
            //arr
            var command = Substitute.For<ICommand>();
            var something = new SomethingThatNeedsACommand(command);

            //act
            something.DoSomething();

            //ass
            command.Received().Execute();
        }

        [Fact]
        public void Teste2()
        {
            //arr
            var command = Substitute.For<ICommand>();
            var something = new SomethingThatNeedsACommand(command);

            //act
            something.DontDoAntything();

            //ass
            command.DidNotReceive().Execute();
        }

        [Fact]
        public void Teste3()
        {
            var command = Substitute.For<ICommand>();
            var repeater = new CommandRepeater(command, 3);

            //act
            repeater.Execute();
            //ass
            command.Received(3).Execute();
        }

        [Fact]
        public void Test4()
        {
            var command = Substitute.For<ICommand>();
            var watcher = new CommandWatcher(command);

            command.Executed += Raise.Event();
            Assert.True(watcher.DidStuff);
        }


        [Fact]
        public void Test5()
        {
            var fuelManagement = new FuelManagement();
            var eventWasRaised = false;

            fuelManagement.LowFuelDetected += (o, e) => eventWasRaised = true;
            fuelManagement.DoSomething();
            Assert.True(eventWasRaised);
        }
    }
}