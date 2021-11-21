namespace UsingNSubstitute
{
    public class CommandRunner
    {
        private readonly ICommand _command;
        public CommandRunner(ICommand command)
        {
            _command = command;
        }

        public void RunCommand()
        {
            _command.Execute();
            _command.Dispose();
        }
    }
    
}