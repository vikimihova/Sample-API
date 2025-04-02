using Microsoft.Extensions.Diagnostics.HealthChecks;
using SampleApi.Utilities;

namespace SampleApi.HealthChecks
{
    public class RandomCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int randomCheck = Random.Shared.Next(1, 4);

            return randomCheck switch
            {
                1 => Task.FromResult(HealthCheckResult.Healthy(OutputMessages.HealthChecks.Random)),
                2 => Task.FromResult(HealthCheckResult.Degraded(OutputMessages.HealthChecks.Random)),
                3 => Task.FromResult(HealthCheckResult.Unhealthy(OutputMessages.HealthChecks.Random)),
                _ => Task.FromResult(HealthCheckResult.Healthy(OutputMessages.HealthChecks.Random))
            };
        }
    }
}