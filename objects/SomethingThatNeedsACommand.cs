namespace UsingNSubstitute
{
    public class SomethingThatNeedsACommand
    {
        ICommand command;

        public SomethingThatNeedsACommand(ICommand command)
        {
            this.command = command;
        }
        public void DoSomething() => command.Execute();
        public void DontDoAntything() { }
    }
}