using NSubstitute;
using Xunit;

namespace UsingNSubstitute
{
    public class UnitTest1
    {
        ICalculator calculator = Substitute.For<ICalculator>();

        [Fact]
        public void Test1()
        {
            calculator.Add(1, 2).Returns(3);

            Assert.Equal(3, calculator.Add(1, 2));
            calculator.Received().Add(1, 2);
            calculator.DidNotReceive().Add(5, 7);
        }

        [Fact]
        public void Test2()
        {
            calculator.Mode.Returns("DEC");
            Assert.Equal("DEC", calculator.Mode);

            calculator.Mode.Returns("HEX");
            Assert.Equal("HEX", calculator.Mode);
        }

        [Fact]
        public void Test3()
        {
            calculator.Add(10, -5);
            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(10, Arg.Is<int>(x => x < 0));
        }

        [Fact]
        public void Test4()
        {
            calculator
                .Add(Arg.Any<int>(), Arg.Any<int>())
                .Returns(x => (int)x[0] + (int)x[1]);

            Assert.Equal(15, calculator.Add(5, 10));
        }

        [Fact]
        public void Test5()
        {
            calculator.Mode.Returns("HEX", "DEC", "BIN");
            Assert.Equal("HEX", calculator.Mode);
            Assert.Equal("DEC", calculator.Mode);
            Assert.Equal("BIN", calculator.Mode);
        }

        [Fact]
        public void Test6()
        {
            bool eventWasRaised = false;
            calculator.PoweringUp += (sender, args) => eventWasRaised = true;

            calculator.PoweringUp += Raise.Event();
            Assert.True(eventWasRaised);
        }
    }
}