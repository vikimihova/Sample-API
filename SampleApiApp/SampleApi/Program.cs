using SampleApi.Data;
using SampleApi.ExtensionMethods.Configuration;
using SampleApi.ExtensionMethods.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ADD SERVICES TO THE CONTAINER
builder.Services.AddOpenApi();
builder.Services.AddCorsService();
builder.Services.AddAllHealthChecks();
builder.Services.AddTransient<Deserializer>();

// BUILD APPLICATION
var app = builder.Build();

// CONFIGURE THE HTTP PIPELINE
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Sample API";
        options.Theme = ScalarTheme.Kepler;
        options.HideClientButton = true;
    });
}

app.UseHttpsRedirection();

app.ApplyCorsConfig();
app.MapAllHealthChecks();

app.AddRootEndpoints();
app.AddCharacterEndpoints();

app.Run();
