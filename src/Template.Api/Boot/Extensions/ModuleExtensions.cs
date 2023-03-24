using Template.Api.Modules.Abstractions;

namespace Template.Api.Boot.Extensions;

public static class ModuleExtensions
{
    /// <summary>
    /// Register the modules <see cref="IModule"/>.
    /// </summary>
    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
    {
        foreach (Type moduleType in DiscoverModules())
        {
            builder.Services.AddSingleton(typeof(IModule), moduleType);
        }
        return builder;
    }

    /// <summary>
    /// Map the endpoints of modules.
    /// </summary>
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (IModule module in app.Services.GetServices<IModule>())
        {
            module.MapEndpoints(app);
        }
        return app;
    }

    /// <summary>
    /// Discover the modules.
    /// </summary>
    private static IEnumerable<Type> DiscoverModules()
    {
        return typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && !p.IsAbstract && p.IsAssignableTo(typeof(IModule)));
    }
}
