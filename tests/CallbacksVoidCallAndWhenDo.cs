using System.Collections.Generic;
using NSubstitute;
using Xunit;

namespace UsingNSubstitute
{
    public class CallbacksVoidCallAndWhenDo
    {
        [Fact]
        public void Teste1()
        {
            var counter = 0;
            var foo = Substitute.For<IFoo>();
            foo.When(x => x.SayHello("World"))
                .Do(x => counter++);

            foo.SayHello("World");
            foo.SayHello("World");
            Assert.Equal(2, counter);
        }

        [Fact]
        public void Teste2()
        {
            var sub = Substitute.For<IFoo>();
            var calls = new List<string>();
            var counter = 0;

            sub
                .When(x => x.Something())
                .Do(
                    Callback.First(x => calls.Add("1"))
                    .Then(x => calls.Add("2"))
                    .Then(x => calls.Add("3"))
                    .ThenKeepDoing(x => calls.Add("+"))
                    .AndAlways(x => counter++)
                );

            for (int i = 0; i < 6; i++)
            {
                sub.Something();
            }

            Assert.Equal("123+++", string.Concat(calls));
            Assert.Equal(6, counter);

        }
    }
}