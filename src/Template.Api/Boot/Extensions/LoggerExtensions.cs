using Serilog;

namespace Template.Api.Boot.Extensions;

public static class LoggerExtensions
{
    /// <summary>
    /// Add Serilog logger.
    /// </summary>
    public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog(ConfigureLogger);

        return builder;
    }

    /// <summary>
    /// Configure Serilog logger based on the appsetting.json with section
    /// name Logging.
    /// </summary>
    private static void ConfigureLogger(HostBuilderContext ctx, LoggerConfiguration configuration)
    {
        // Read from configuration the section named "Logging"
        // More information about ReadFrom property at official wiki: https://github.com/serilog/serilog/wiki/AppSettings
        configuration.ReadFrom.Configuration(ctx.Configuration, "Logging");
    }
}
