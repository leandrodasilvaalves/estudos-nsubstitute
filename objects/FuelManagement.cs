using System;

namespace UsingNSubstitute
{
    public class FuelManagement
    {
        public event EventHandler<LowFuelWarningEventArgs> LowFuelDetected;
        public void DoSomething()
        {
            LowFuelDetected?.Invoke(this, new LowFuelWarningEventArgs(15));
        }
    }
}