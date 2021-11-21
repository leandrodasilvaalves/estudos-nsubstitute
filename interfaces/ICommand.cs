using System;

namespace UsingNSubstitute
{
    public interface ICommand : IDisposable
    {
        void Execute();
        event EventHandler Executed;
    }
    
}