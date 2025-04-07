using Microsoft.Extensions.Diagnostics.HealthChecks;
using SampleApi.Utilities.Messages;

namespace SampleApi.HealthChecks
{
    public class HealthyCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy(OutputMessages.HealthChecks.Healthy));
        }
    }
}