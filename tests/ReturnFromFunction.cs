using NSubstitute;
using Xunit;

namespace UsingNSubstitute
{
    public class ReturnFromFunction
    {
        ICalculator calculator = Substitute.For<ICalculator>();

        [Fact]
        public void Test1()
        {
            var counter = 0;
            calculator
                .Add(default, default)
                .ReturnsForAnyArgs(x =>
                {
                    counter++;
                    return 0;
                });
            calculator.Add(7, 3);
            calculator.Add(2, 2);
            calculator.Add(11, -3);
            Assert.Equal(3, counter);
        }

        [Fact]
        public void Test2()
        {
            var counter = 0;
            calculator
                .Add(default, default)
                .ReturnsForAnyArgs(x => 0)
                .AndDoes(x => counter++);

            calculator.Add(7, 3);
            calculator.Add(2, 2);
            Assert.Equal(2, counter);
        }
    }
}