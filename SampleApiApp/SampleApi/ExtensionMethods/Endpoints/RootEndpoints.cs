﻿using System.Net.Security;

namespace SampleApi.ExtensionMethods.Endpoints
{
    public static class RootEndpoints
    {
        public static void AddRootEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => "Hello World");
        }
    }
}
