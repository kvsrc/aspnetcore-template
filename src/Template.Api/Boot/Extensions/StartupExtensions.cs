namespace Template.Api.Boot.Extensions;

public static class StartupExtensions
{
    /// <summary>
    /// Register the services.
    /// </summary>
    public static void Register(this WebApplicationBuilder builder)
    {
        builder.AddLogger();
        builder.AddApiExplorers();
        builder.AddJsonSerializerOptions();
        builder.AddCorsPolicies();
        builder.AddDatabases();
        builder.RegisterModules();
    }

    /// <summary>
    /// Configure the services.
    /// </summary>
    public static void Configure(this WebApplication app)
    {
        app.UseApiExplorers();
        app.UseHttpsRedirection();
        app.UseCorsPolicies();
        app.MapEndpoints();
    }
}
