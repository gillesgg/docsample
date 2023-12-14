using Microsoft.AspNetCore.Builder;
using System;

namespace BuggyBits
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
            return builder.AddOpenTelemetry();
        }
    }
}
