namespace Template.Api.Boot.Extensions;

public static class DatabaseExtensions
{
    /// <summary>
    /// Add and configure the databases.
    /// </summary>
    /// <param name="builder">The builder where to configure the databases.
    /// </param>
    public static WebApplicationBuilder AddDatabases(this WebApplicationBuilder builder)
    {
        return builder;
    }
}
