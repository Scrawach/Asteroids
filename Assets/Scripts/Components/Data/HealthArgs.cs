using System;

namespace Components.Data
{
    [Serializable]
    public readonly struct HealthArgs
    {
        public readonly int Current;
        public readonly int Max;

        public HealthArgs(int current, int max)
        {
            Current = current;
            Max = max;
        }
    }
}