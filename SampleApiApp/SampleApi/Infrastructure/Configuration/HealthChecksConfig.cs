using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

using SampleApi.Utilities.Performance.HealthChecks;

namespace SampleApi.Infrastructure.Configuration
{
    public static class HealthChecksConfig
    {
        public static void AddAllHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<RandomCheck>("Random", tags: ["random"])
                .AddCheck<RandomCheck>("Healthy", tags: ["healthy"])
                .AddCheck<RandomCheck>("Degraded", tags: ["degraded"])
                .AddCheck<RandomCheck>("Unhealthy", tags: ["unhealthy"]);
        }

        public static void MapAllHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health");
            app.MapHealthChecks("/health/healthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("healthy")
            });
            app.MapHealthChecks("/health/degraded", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("degraded")
            });
            app.MapHealthChecks("/health/unhealthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("unhealthy")
            });
            app.MapHealthChecks("/health/random", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("random")
            });

            // with UI
            app.MapHealthChecks("/health/ui", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/healthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("healthy"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/degraded", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("degraded"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/unhealthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("unhealthy"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/random", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("random"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
