namespace SampleApi.Utilities.Messages
{
    public static class OutputMessages
    {
        public static class HealthChecks
        {
            public const string Healthy = "This is a test healthy service.";
            public const string Unhealthy = "This is a test unhealthy service.";
            public const string Degraded = "This is a test degraded service.";
            public const string Random = "This is a test random service.";
        }
    }
}