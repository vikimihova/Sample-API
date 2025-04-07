namespace SampleApi.Utilities.Performance
{
    public static class PerformanceManagement
    {
        public static class Delay
        {
            private const int maxDelayInMilliseconds = 300000;
            private const int minDelayInMilliseconds = 0;

            public static int EnforceDelayLimits(int delay)
            {
                if (delay > maxDelayInMilliseconds)
                {
                    delay = maxDelayInMilliseconds;
                }

                if (delay < minDelayInMilliseconds)
                {
                    delay = minDelayInMilliseconds;
                }

                return delay;
            }
        }
    }
}
