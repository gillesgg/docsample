using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.EventCounterCollector;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace BuggyBits
{
    public static class WebApplicationBuilderExtensions
    {
        internal static WebApplicationBuilder AddOpenTelemetry(this WebApplicationBuilder webApplicationBuilder)
        {
            var isDevelopment = webApplicationBuilder.Environment.IsDevelopment();

            var connection = webApplicationBuilder.Configuration["ApplicationInsights:ConnectionString"];

            if (string.IsNullOrEmpty(connection))
                connection = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");

            webApplicationBuilder.Logging.ClearProviders();
            webApplicationBuilder.Logging.AddConsole();

            if (isDevelopment)
                webApplicationBuilder.Logging.AddDebug();


            webApplicationBuilder.Services.AddApplicationInsightsTelemetry();
            TelemetryConfiguration config = TelemetryConfiguration.CreateDefault();
            config.ConnectionString = connection;

            TelemetryClient client = new TelemetryClient(config);

            webApplicationBuilder.Logging.AddApplicationInsights(
                    configureTelemetryConfiguration: (config) =>
                        config.ConnectionString = connection,
                        configureApplicationInsightsLoggerOptions: (options) => { }
                );


            webApplicationBuilder.Services
                .ConfigureCounters(isDevelopment)
                .ConfigureTracing(isDevelopment);

            return webApplicationBuilder.ConfigureLogging(isDevelopment);
        }

        private static IServiceCollection ConfigureTracing(this IServiceCollection services, bool isDevelopment)
        {
            return services;
        }

        private static IServiceCollection ConfigureCounters(this IServiceCollection services, bool isDevelopment)
        {
            services.ConfigureTelemetryModule<EventCounterCollectionModule>((module, o) =>
            {
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "cpu-usage"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "working-set"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "gc-heap-size"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "gen-0-gc-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "gen-1-gc-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "gen-2-gc-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "time-in-gc"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "gen-0-size"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "gen-1-size"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "gen-2-size"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "loh-size"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "alloc-rate"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "assembly-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "exception-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "threadpool-thread-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "monitor-lock-contention-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "threadpool-queue-length"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "threadpool-completed-items-count"));
                module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", "active-timer-count"));
                module.Counters.Add(new EventCounterCollectionRequest("Microsoft.AspNetCore", "requests-per-second"));
                module.Counters.Add(new EventCounterCollectionRequest("Microsoft.AspNetCore", "total-requests"));
                module.Counters.Add(new EventCounterCollectionRequest("Microsoft.AspNetCore", "current-requests"));
                module.Counters.Add(new EventCounterCollectionRequest("Microsoft.AspNetCore", "failed-requests"));
            });
            return services;
        }

        private static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder webApplicationBuilder, bool isDevelopment)
        {
            return webApplicationBuilder;
        }
    }
}
