using Microsoft.Extensions.Diagnostics.HealthChecks;
using SampleApi.Utilities.Messages;

namespace SampleApi.Utilities.Performance.HealthChecks
{
    public class UnhealthyCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy(OutputMessages.HealthChecks.Unhealthy));
        }
    }
}