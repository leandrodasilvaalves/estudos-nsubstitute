using System;
using NSubstitute;
using Xunit;

namespace UsingNSubstitute
{
    public class RaisingEvents
    {
        IEngine engine = Substitute.For<IEngine>();

        [Fact]
        public void Teste1()
        {
            var wasCalled = false;
            engine.Idling += (sender, args) => wasCalled = true;
            engine.Idling += Raise.EventWith(new Object(), new EventArgs());
            Assert.True(wasCalled);
        }

        [Fact]
        public void Teste2()
        {
            var wasCalled = false;
            engine.Idling += (sender, args) => wasCalled = true;
            engine.Idling += Raise.Event();
            Assert.True(wasCalled);
        }

        [Fact]
        public void Teste3()
        {
            var numberOfEvents = 0;
            engine.LowFuelWarning += (sender, args) => numberOfEvents++;
            
            engine.LowFuelWarning += Raise.EventWith(new LowFuelWarningEventArgs(10));
            engine.LowFuelWarning += Raise.EventWith(new Object(), new LowFuelWarningEventArgs(10));

            Assert.Equal(2, numberOfEvents);
        }
    }
}