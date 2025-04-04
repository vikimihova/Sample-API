﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using SampleApi.Utilities;

namespace SampleApi.HealthChecks
{
    public class UnhealthyCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy(OutputMessages.HealthChecks.Unhealthy));
        }
    }
}