namespace SampleApi.Infrastructure.Configuration
{
    public static class CorsConfig
    {
        private const string AllowAllPolicy = "AllowAll";

        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowAllPolicy, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }

        public static void ApplyCorsConfig(this WebApplication app)
        {
            app.UseCors(AllowAllPolicy);
        }
    }
}
