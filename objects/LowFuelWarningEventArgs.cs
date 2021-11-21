using System;

namespace UsingNSubstitute
{
    public class LowFuelWarningEventArgs : EventArgs
    {
        public int PercentLeft { get; }
        public LowFuelWarningEventArgs(int percentLeft) => PercentLeft = percentLeft;
    }
}