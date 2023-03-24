using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Template.Api.Boot.Extensions;

public static class CorsExtensions
{
    /// <summary>
    /// Add Cors Policies.
    /// </summary>
    public static WebApplicationBuilder AddCorsPolicies(this WebApplicationBuilder builder)
    {
        CorsOptions corsPolocies = GetCorsOptions(builder.Configuration);

        // get a scope, then get the logger, then dispose the scope.
        using IServiceScope serviceScope = builder.Services.BuildServiceProvider().CreateScope();

        ILogger<CorsOptions> logger = serviceScope.ServiceProvider.GetRequiredService<
            ILogger<CorsOptions>
        >();

        builder.Services.AddCors(options =>
        {
            foreach (KeyValuePair<string, CorsPolicyOptions> item in corsPolocies.Policies)
            {
                string[] origins = item.Value.Policy.Origins.ToArray();
                string[] headers = item.Value.Policy.Headers.ToArray();
                logger.LogInformation(
                    $"Building Cors with origins: {string.Join(", ", origins)}; headers: {string.Join(", ", headers)}"
                );

                options.AddPolicy(
                    item.Value.Name,
                    builder =>
                    {
                        builder
                            .WithOrigins(origins)
                            .WithHeaders(headers)
                            .AllowCredentials()
                            .AllowAnyMethod();
                    }
                );
            }
        });
        return builder;
    }

    /// <summary>
    /// Use Cors Policies.
    /// </summary>
    public static WebApplication UseCorsPolicies(this WebApplication app)
    {
        // we know there is an instance of it.
        ILogger<CorsOptions> _logger = app.Services.GetRequiredService<ILogger<CorsOptions>>();

        CorsOptions corsPolocies = GetCorsOptions(app.Configuration);

        foreach (KeyValuePair<string, CorsPolicyOptions> item in corsPolocies.Policies)
        {
            _logger.LogInformation($"Using Cors policy: {item.Value.Name}");

            app.UseCors(item.Value.Name);
        }

        return app;
    }

    private static CorsOptions GetCorsOptions(IConfiguration configuration)
    {
        return configuration.GetSection(CorsOptions.SectionName).Get<CorsOptions>()
            ?? throw new InvalidOperationException(
                "No cors policies found. Please define policies in configuration file."
            );
    }
}

public class CorsOptions
{
    public const string SectionName = "Cors";

    public Dictionary<string, CorsPolicyOptions> Policies { get; set; } = new();
}

public class CorsPolicyOptions
{
    public string Name { get; set; }
    public CorsPolicy Policy { get; set; } = new();
}
